// See https://aka.ms/new-console-template for more information
using MockingHttpConsole;

Console.WriteLine("*****************************************");
Console.WriteLine("************  Make Post  ****************");
Console.WriteLine("*****************************************");


HttpPost httpPosts = new HttpPost(new HttpClient());

var post = await httpPosts.CreatePost("Example Post");

Console.WriteLine(post);

Console.WriteLine("*****************************************");
Console.WriteLine("************  Get Posts  ****************");
Console.WriteLine("*****************************************");

var getPosts = await httpPosts.GetPosts();

foreach (var p in getPosts)
{
    Console.WriteLine(p);
   
}




