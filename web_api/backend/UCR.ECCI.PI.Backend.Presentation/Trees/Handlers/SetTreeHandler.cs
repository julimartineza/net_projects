using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCR.ECCI.PI.Backend.Application.TreeServices;
using UCR.ECCI.PI.Backend.Domain.Trees.Entities;
using UCR.ECCI.PI.Backend.Presentation.Trees.Mappers;
using UCR.ECCI.PI.Backend.Presentation.Trees.Requests;

namespace UCR.ECCI.PI.Backend.Presentation.Trees.Handlers;

/// <summary>
/// Class to handle the set tree request.
/// </summary>
public static class SetTreeHandler
{
    /// <summary>
    /// Handles the request to register a new tree in the system.
    /// </summary>
    /// <param name="treeService">The tree service.</param>
    /// <param name="treeParams">The parameters to set the tree's information.</param>
    /// <returns>An HTTP result indicating success or failure.</returns>
    internal static async Task<IResult> HandleAsync(
        [FromServices] ITreeService treeService,
        [FromBody] SetTreeRequest treeParams)
    {
        if (treeParams == null)
        {
            var validationError = new
            {
                Message = "Invalid input provided.",
                ErrorCode = 400,
                Details = "Missing required fields."
            };
            return Results.BadRequest(validationError);
        }

        try
        {
            var tree = treeParams.tree.ToEntity();

            await treeService.SetTree(tree);

            var successResponse = new
            {
                Message = "Tree created successfully.",
                StatusCode = 200,
                Details = "The tree was created successfully.",
                Data = tree
            };
            return Results.Ok(successResponse);
        }
        catch (AggregateException ae)
        {
            var errorDetails = string.Join("\n", ae.InnerExceptions.Select(e => e.Message));
            var errorResponse = new
            {
                Message = "Error creating tree.",
                ErrorCode = 400,
                Details = errorDetails
            };
            return Results.BadRequest(errorResponse);
        }
        catch (Exception ex)
        {
            var errorResponse = new
            {
                Message = "An unexpected error occurred.",
                ErrorCode = 500,
                Details = ex.Message
            };
            return Results.Problem(errorResponse.Details, statusCode: 500);
        }
    }
}
