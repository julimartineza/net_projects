namespace UCR.ECCI.PI.Backend.Application.UserServices;

/// <summary>
/// Record to receive the result of the GetUser method
/// </summary>
public record GetUserResult(
    Guid Id,
    string Username,
    string Avatar,
    bool IsActive,
    string Email
);

/// <summary>
/// Record to receive the result of the ListUsers method
/// </summary>
public record ListUsersResult(
    Guid Id,
    string Username,
    string Avatar,
    bool IsActive,
    string Email
    //bool IsPerson
);

/// <summary>
/// Record to receive the parameters of the SetUser method (includes Id only for creation)
/// </summary>
public record SetUserParams(
    Guid Id, 
    string Username,
    //string EncryptedPassword,
    string Avatar,
    bool IsActive,
    string Email,
    bool IsPerson
);

/// <summary>
/// Record to receive the parameters of the EditUser method (Id excluded as it is immutable)
/// </summary>
public record EditUserParams(
    Guid Id,
    string Username,
    string Avatar,
    string Email
);


/// <summary>
/// Record to receive the parameters of the ChangeIsActive method
/// </summary>
public record ChangeIsActiveParams(
    Guid Id
);
