using LexiBox.API.Abstract;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LexiBox.API.Features.GetVocabularyById;

public class GetVocabularyByIdEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/api/v1/vocabularies/{id}", Handle);
    }

    private async Task<IResult> Handle(
        [FromRoute] Guid id, IMediator mediator, CancellationToken cancellationToken)
    {
        var command = new GetVocabularyByIdQuery(id);

        var response = await mediator.Send(command, cancellationToken);

        if (response.IsFailure)
        {
            if (response.Error == VocabularyErrors.NotFound) return Results.NotFound(response.Error); 

            return Results.BadRequest(response.Error);
        }

        return Results.Ok(response);
    }
}
