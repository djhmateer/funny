using Core.Models;
using Core.Services;
using System;
using System.Data.SqlClient;

namespace ConsoleImporter {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello world");

            // Connect to (localdb)\projects.HumourAzure and get all Stories
            var connectionString = @"server=(localdb)\projects;database=HumourAzure;Trusted_Connection=True;";

            using (var connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (var command = new SqlCommand("SELECT StoryTypeID, Title, Content, VideoURL, ImageURL, AddedDate, Rating FROM Stories", connection)) {
                    using (var reader = command.ExecuteReader()) {
                        while (reader.Read()) {
                            var storyTypeID = reader["StoryTypeID"].ToString();
                            var title = reader["Title"].ToString();
                            var content = reader["Content"].ToString();
                            var videoURL = reader["VideoURL"].ToString();
                            var imageURL = reader["ImageURL"].ToString();
                            var addedDate = Convert.ToDateTime(reader["AddedDate"]);
                            var rating = Convert.ToInt32(reader["Rating"].ToString());

                            var storyType = StoryType.Joke;
                            if (storyTypeID == "1") storyType = StoryType.Joke;
                            if (storyTypeID == "2") storyType = StoryType.Video;

                            // Use API to insert into our system checking business rules
                            var sc = new StoryCreator();
                            var sa = new StoryApplication{
                                Content = content,
                                ImageURL = imageURL,
                                Rating = rating,
                                StoryType = storyType,
                                Title = title,
                                VideoURL = videoURL,
                                CreatedAt = addedDate
                            };

                            var result = sc.CreateOrEditStory(sa);
                            if (result.StoryApplication.IsInvalid()){
                                Console.WriteLine(result.StoryApplication.Title + ": " + result.StoryApplication.Message);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Finished");
            Console.ReadLine();
        }
    }
}
