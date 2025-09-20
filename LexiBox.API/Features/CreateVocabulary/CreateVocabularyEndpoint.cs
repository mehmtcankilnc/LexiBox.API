using FluentValidation;
using LexiBox.API.Abstract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LexiBox.API.Features.CreateVocabulary;

public sealed class CreateVocabularyEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPost("/api/v1/vocabularies", Handle);
    }

    private static async Task<IResult> Handle(
        [FromBody] CreateVocabularyRequest request, IMediator mediator, 
        IValidator<CreateVocabularyRequest> validator, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var command = new CreateVocabularyCommand(
            request.Word, request.Meaning, request.Category);

        var response = await mediator.Send(command, cancellationToken);

        if (response.IsFailure)
        {
            return Results.BadRequest(response.Error);
        }

        return Results.Ok(response);
    }
}
