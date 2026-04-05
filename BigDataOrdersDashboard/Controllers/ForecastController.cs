using BigDataOrdersDashboard.Context;
using BigDataOrdersDashboard.Dtos.ForecastDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;

namespace BigDataOrdersDashboard.Controllers
{
    public class ForecastController : Controller
    {
        private readonly BigDataOrdersDbContext _context;
        private readonly MLContext _mLContext;

        public ForecastController(BigDataOrdersDbContext context, MLContext mLContext)
        {
            _context = context;
            _mLContext = mLContext;
        }

        public IActionResult PaymentMethodForecast()
        {
            // 2026 verilerini çek
            var startDate = new DateTime(2026, 1, 1);
            var endDate = new DateTime(2026, 12, 31);

            var monthlyPaymentData = _context.Orders
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .AsEnumerable()
                .GroupBy(o => new
                {
                    Month = new DateTime(o.OrderDate.Year, o.OrderDate.Month, 1),
                    o.PaymentMethod
                })
                .Select(g => new
                {
                    Month = g.Key.Month,
                    PaymentMethod = g.Key.PaymentMethod,
                    OrderCount = g.Count()
                })
                .OrderBy(x => x.Month)
                .ToList();

            var forecasts = new List<object>();

            foreach (var method in monthlyPaymentData.Select(x => x.PaymentMethod).Distinct())
            {
                var methodData = monthlyPaymentData
                    .Where(x => x.PaymentMethod == method)
                    .Select((x, idx) => new PaymentForecastData
                    {
                        PaymentMethod = method,
                        MonthIndex = idx + 1,
                        OrderCount = x.OrderCount
                    })
                    .ToList();

                int count = methodData.Count;

                // Yeterli veri yoksa atla
                if (count < 2)
                    continue;

                // windowSize'ı veriye göre ayarla
                int windowSize = Math.Min(4, count - 1);

                if (windowSize < 1)
                    continue;

                int seriesLength = count;
                int trainSize = Math.Max(seriesLength, windowSize * 2);

                var dataView = _mLContext.Data.LoadFromEnumerable(methodData);

                var pipeline = _mLContext.Forecasting.ForecastBySsa(
                    outputColumnName: "ForecastedValues",
                    inputColumnName: nameof(PaymentForecastData.OrderCount),
                    windowSize: windowSize,
                    seriesLength: seriesLength,
                    trainSize: trainSize,
                    horizon: 3,
                    confidenceLevel: 0.95f
                );

                var model = pipeline.Fit(dataView);
                var engine = model.CreateTimeSeriesEngine<PaymentForecastData, PaymentForecastPrediction>(_mLContext);

                var prediction = engine.Predict();

                for (int i = 0; i < prediction.ForecastedValues.Length; i++)
                {
                    forecasts.Add(new
                    {
                        PaymentMethod = method,
                        Month = new DateTime(2027, i + 1, 1).ToString("yyyy MMM"),
                        ForecastedCount = (int)prediction.ForecastedValues[i]
                    });
                }
            }

            return View(forecasts);
        }

        public IActionResult GermanyCitiesForecast()
        {
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2026, 12, 31);

            var germanyCityData = _context.Orders
                .Include(o => o.Customer)
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate && o.Customer.CustomerCountry == "Almanya")
                .AsEnumerable()
                .GroupBy(o => new
                {
                    o.Customer.CustomerCity,
                    Year = o.OrderDate.Year,
                    Month = o.OrderDate.Month
                })
                .Select(g => new
                {
                    City = g.Key.CustomerCity,
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    OrderCount = g.Count()
                })
                .OrderBy(x => x.City)
                .ThenBy(x => x.Year).ThenBy(x => x.Month)
                .ToList();

            var forecasts = new List<object>();

            foreach (var city in germanyCityData.Select(x => x.City).Distinct())
            {
                var cityData = germanyCityData
                    .Where(x => x.City == city)
                    .Select((x, idx) => new GermanyCitiesForecastData
                    {
                        City = city,
                        MonthIndex = idx + 1,
                        OrderCount = x.OrderCount
                    })
                    .ToList();

                int count = cityData.Count;

                if (count < 2)
                    continue;

                int windowSize = Math.Min(12, count / 2);
                if (windowSize < 1)
                    continue;

                int seriesLength = count;
                int trainSize = Math.Max(seriesLength, windowSize * 2);

                var dataView = _mLContext.Data.LoadFromEnumerable(cityData);

                var pipeline = _mLContext.Forecasting.ForecastBySsa(
                    outputColumnName: "ForecastedValues",
                    inputColumnName: nameof(GermanyCitiesForecastData.OrderCount),
                    windowSize: windowSize,
                    seriesLength: seriesLength,
                    trainSize: trainSize,
                    horizon: 12,
                    confidenceLevel: 0.95f
                );

                var model = pipeline.Fit(dataView);
                var engine = model.CreateTimeSeriesEngine<GermanyCitiesForecastData, GermanyCitiesForecastPrediction>(_mLContext);

                var prediction = engine.Predict();

                var yearlyForecast = (int)prediction.ForecastedValues.Sum();

                var year2025Count = germanyCityData
                    .Where(x => x.City == city && x.Year == 2026)
                    .Sum(x => x.OrderCount);

                var diff = yearlyForecast - year2025Count;
                double? growthRate = year2025Count > 0
                    ? (diff / (double)year2025Count) * 100.0
                    : (double?)null;

                forecasts.Add(new
                {
                    City = city,
                    Year2024 = germanyCityData.Where(x => x.City == city && x.Year == 2025).Sum(x => x.OrderCount),
                    Year2025 = year2025Count,
                    Year = "2027",
                    ForecastedCount = yearlyForecast,
                    DiffTo2025 = diff,
                    GrowthRate = growthRate
                });
            }

            return View(forecasts);
        }
    }
}