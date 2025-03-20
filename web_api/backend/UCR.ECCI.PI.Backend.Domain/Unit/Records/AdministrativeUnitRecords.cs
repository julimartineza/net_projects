namespace UCR.ECCI.PI.Backend.Domain.Unit.Records;

/// <summary>
/// Record that represents the result of a query for an administrative hierarchy.
/// </summary>
/// <param name="Id"></param>
/// <param name="HierarchyString"></param>
public record AdministrativeHierarchyResult(
    string Id,
    string HierarchyString
);

/// <summary>
/// Record that represents the result of a query for an administrative unit.
/// </summary>
/// <param name="Name"></param>
/// <param name="status"></param>
public record AdministrativeUnitActiveStatus(
    string Name,
    bool status
);