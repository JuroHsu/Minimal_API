using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace Minimal_API.MinimalAPI
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.MapGroup("/minimal/user");

            endpoints.MapGet("/", GetAllAnnouncement);
            endpoints.MapGet("/{id}", GetAnnouncement);
        }

        static List<User> GetAllAnnouncement() =>
            [
                new() { Id = 1, Name = "Juro Hsu", Position = "Software Engineer" },
                new() { Id = 2, Name = "Juro Hsu", Position = "Hardware Engineer" },
            ];
        static Results<Ok<User>, NotFound> GetAnnouncement(int Id)
        {
            List<User> users = GetAllAnnouncement();
            var data = users.Find(x => x.Id == Id);
            return data is null ? TypedResults.NotFound() : TypedResults.Ok(data);
        }
    }
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
    }
}
