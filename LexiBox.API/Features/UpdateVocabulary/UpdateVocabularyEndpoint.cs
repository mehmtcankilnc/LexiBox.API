using FluentValidation;
using LexiBox.API.Abstract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LexiBox.API.Features.UpdateVocabulary;

public sealed class UpdateVocabularyEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapPut("/api/v1/vocabularies/{id}", Handle);
    }

    private async Task<IResult> Handle(
        [FromRoute] Guid id, IValidator<UpdateVocabularyRequest> validator,
        UpdateVocabularyRequest request, IMediator mediator, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return Results.ValidationProblem(validationResult.ToDictionary());
        }

        var command = new UpdateVocabularyCommand(
            id, request.Word, request.Meaning, request.Category, request.State);

        var response = await mediator.Send(command, cancellationToken);

        if (response.IsFailure)
        {
            if (response.Error == VocabularyErrors.NotFound)
                return Results.NotFound(response.Error);

            return Results.BadRequest(response.Error);
        }

        return Results.Ok(response);
    }
}
