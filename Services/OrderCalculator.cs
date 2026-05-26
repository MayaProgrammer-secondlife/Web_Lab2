namespace AtelierWasm.Services;

public static class OrderCalculator
{
    private static readonly Dictionary<ServiceType, (decimal Min, decimal Max, int Days)> _base = new()
    {
        [ServiceType.Tailoring]   = (5_000m,  15_000m, 7),
        [ServiceType.Repair]      = (150m,     500m,   1),
        [ServiceType.Alterations] = (400m,    1_000m,  1),
    };

    private static decimal ComplexityFactor(int level) => level switch
    {
        1 => 1.0m,
        2 => 1.6m,
        3 => 2.5m,
        _ => throw new ArgumentOutOfRangeException(nameof(level), "Уровень сложности: 1–3.")
    };

    public static OrderEstimate Calculate(OrderRequest request)
    {
        if (request.ComplexityLevel is < 1 or > 3)
            throw new ArgumentOutOfRangeException(nameof(request.ComplexityLevel),
                "Уровень сложности должен быть от 1 до 3.");

        if (request.FabricMeters < 0)
            throw new ArgumentOutOfRangeException(nameof(request.FabricMeters),
                "Количество метров ткани не может быть отрицательным.");

        var (baseMin, baseMax, baseDays) = _base[request.Type];
        var factor = ComplexityFactor(request.ComplexityLevel);

        decimal fabricCost = request.Type == ServiceType.Tailoring
            ? Math.Round(request.FabricMeters * 400m)
            : 0m;

        decimal minCost = Math.Round(baseMin * factor + fabricCost, 0, MidpointRounding.AwayFromZero);
        decimal maxCost = Math.Round(baseMax * factor + fabricCost, 0, MidpointRounding.AwayFromZero);
        int days        = (int)Math.Ceiling(baseDays * factor);

        return new OrderEstimate(minCost, maxCost, days);
    }
}
