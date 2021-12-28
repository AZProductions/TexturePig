using Microsoft.AspNetCore.Mvc;
using Supabase.Realtime;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using static Supabase.Client;
using System.Net;
using System.Reflection;

namespace TexturePig.API.Controllers
{
    public class PackMetaController : Controller
    {
        [Route("v1/pack/meta/{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { id });
            Supabase.Client.InitializeAsync(Verification.ENV.SUPABASE_URL, Verification.ENV.SUPABASE_KEY, new Supabase.SupabaseOptions { AutoConnectRealtime = true, ShouldInitializeRealtime = true });

            try
            {
                var instance = Supabase.Client.Instance;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            var reference = Supabase.Client.Instance.From<Models.Channel>();

            reference.On(Supabase.Client.ChannelEventType.All, (sender, ev) =>
            {
                Debug.WriteLine($"[{ev.Response.Event}]:{ev.Response.Topic}:{ev.Response.Payload.Record}");
            });

            //reference.Insert(new Models.Channel { Slug = GenerateName(10), InsertedAt = DateTime.Now });

            #region Storage
            var storage = Supabase.Client.Instance.Storage;

            var exists = (storage.GetBucket("testing") != null);
            if (!exists)
                storage.CreateBucket("testing", new Supabase.Storage.BucketUpsertOptions { Public = true });

            var buckets = storage.ListBuckets();

            foreach (var b in buckets)
                Debug.WriteLine($"[{b.Id}] {b.Name}");

            var bucket = storage.From("testing");
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Replace("file:", "");
            var imagePath = Path.Combine(basePath, "Assets", "supabase-csharp.png");

            Debug.WriteLine(bucket.Upload(imagePath, "supabase-csharp.png", new Supabase.Storage.FileOptions { Upsert = true }, (sender, args) => Debug.WriteLine($"Upload Progress: {args.ProgressPercentage}%")));
            Debug.WriteLine(bucket.GetPublicUrl("supabase-csharp.png"));
            Debug.WriteLine(bucket.CreateSignedUrl("supabase-csharp.png", 3600));

            var bucketItems = bucket.List();

            foreach (var item in bucketItems)
                Debug.WriteLine($"[{item.Id}] {item.Name} - {item.CreatedAt}");

            Debug.WriteLine(bucket.Download("supabase-csharp.png", Path.Combine(basePath, "testing-download.png"), (sender, args) => Debug.WriteLine($"Download Progress: {args.ProgressPercentage}%")));

            storage.EmptyBucket("testing");
            storage.DeleteBucket("testing");
            #endregion
        }

        // From: https://stackoverflow.com/a/49922533/3629438
        static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }
    }
}