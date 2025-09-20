using FluentValidation;
using LexiBox.API.Abstract;
using MediatR;

namespace LexiBox.API.Features.GetVocabularies;

public sealed class GetVocabulariesEndpoint : IEndpoint
{
    public void MapEndpoint(WebApplication app)
    {
        app.MapGet("/api/v1/vocabularies", Handle);
    }

    private async Task<IResult> Handle([AsParameters] GetVocabulariesRequest request,
        IMediator mediator, CancellationToken cancellationToken)
    {
        var query = new GetVocabulariesQuery(request.State, request.Category);

        var response = await mediator.Send(query, cancellationToken);

        if (response.IsFailure)
        {
            return Results.BadRequest(response.Error);
        }

        return Results.Ok(response);
    }
}
