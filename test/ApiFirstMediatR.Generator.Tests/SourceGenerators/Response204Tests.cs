namespace ApiFirstMediatR.Generator.Tests.SourceGenerators;

public class Response204Tests : TestBase
{
    [Fact]
    public void ValidAPISpec_With204Response_GeneratesValidCode()
    {
        var result = RunGenerators("With201Response", ApiSpec);

        result.Diagnostics.Should().BeEmpty();
        result.GeneratedSources.Should()
                .ContainEquivalentSyntaxTree("default/Controllers_PetsController.g.cs", ExpectedController);
    }

    private const string ApiSpec = @"openapi: 3.0.3
info:
  version: 1.0.0
  title: Swagger Petstore
  description: A sample API that uses a petstore as an example to demonstrate features in the OpenAPI 3.0 specification
  termsOfService: http://swagger.io/terms/
  contact:
    name: Swagger API Team
    email: apiteam@swagger.io
    url: http://swagger.io
  license:
    name: Apache 2.0
    url: https://www.apache.org/licenses/LICENSE-2.0.html
servers:
  - url: http://petstore.swagger.io/api
paths:
  /pets/{id}:
    delete:
      description: deletes a single pet based on the ID supplied
      operationId: deletePet
      parameters:
        - name: id
          in: path
          description: ID of pet to delete
          required: true
          schema:
            type: integer
            format: int64
      responses:
        '204':
          description: pet deleted
        default:
          description: unexpected error
          content:
            application/json:
              schema:
                $ref: '#/components/schemas/Error'
components:
  schemas:
    Error:
      type: object
      required:
        - code
        - message
      properties:
        code:
          type: integer
          format: int32
        message:
          type: string";

    private const string ExpectedController = @"// <auto-generated/>
#nullable enable

namespace With201Response.Controllers
{
    public sealed class PetsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly MediatR.IMediator _mediator;

        public PetsController(MediatR.IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// deletes a single pet based on the ID supplied
        /// </summary>
        /// <param name=""id"">ID of pet to delete</param>
        /// <returns>pet deleted</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete(""/pets/{id}"")]
        [Microsoft.AspNetCore.Mvc.ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status204NoContent)]
        public async System.Threading.Tasks.Task<Microsoft.AspNetCore.Mvc.ActionResult> DeletePet(long id, System.Threading.CancellationToken cancellationToken)
        {
            var request = new With201Response.Requests.DeletePetCommand(id);

            return NoContent();
        }
    }
}";
}