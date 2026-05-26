namespace AtelierWasm.Services;

public enum ServiceType
{
    Tailoring,    // Индивидуальный пошив
    Repair,       // Ремонт
    Alterations   // Подгонка по фигуре
}

public sealed record OrderRequest(
    ServiceType Type,
    decimal FabricMeters,
    int ComplexityLevel   // 1 = простой, 2 = средний, 3 = сложный
);

public sealed record OrderEstimate(
    decimal MinCost,
    decimal MaxCost,
    int EstimatedDays
);
