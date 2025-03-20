namespace UCR.ECCI.PI.Backend.Application.UserServices;

/// <summary>
/// Record to receive the result of the GetPerson method
/// </summary>
public record GetPersonResult(
    Guid Id,
    string FullName,
    string Nickname,
    string Username,
    string Email
);

/// <summary>
/// Record to receive the result of the ListPersons method
/// </summary>
public record ListPersonsResult(
    Guid Id,
    string FullName,
    string Nickname,
    string Username,
    string Email
);

/// <summary>
/// Record to receive the parameters of the SetPerson method (includes Id only for creation)
/// </summary>
public record SetPersonParams(
    Guid Id,
    string FullName,
    string Nickname,
    string Username,
    string Email
    //string EncryptedPassword
);

/// <summary>
/// Record to receive the parameters of the EditPerson method (Id excluded as it is immutable)
/// </summary>
//public record EditPersonParams(
//    string FullName,
//    string Nickname,
//    string Username
//);

///// <summary>
///// Record to receive the parameters of the EditPerson method (Id excluded as it is immutable)
///// </summary>
//public record EditPersonPasswordParams(
//    string Email,
//    string CurrentEncryptedPassword,
//    string NewEncryptedPassowrd
//);
