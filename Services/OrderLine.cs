namespace AtelierWasm.Services;

public enum ServiceType
{
    Tailoring,    
    Repair,       
    Alterations  
}

public sealed record OrderRequest(
    ServiceType Type,
    decimal FabricMeters,
    int ComplexityLevel   
);

public sealed record OrderEstimate(
    decimal MinCost,
    decimal MaxCost,
    int EstimatedDays
);
