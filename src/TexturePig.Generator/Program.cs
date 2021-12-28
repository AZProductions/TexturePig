

using System.IO;
using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Newtonsoft.Json;
using TexturePig;

public class Program
{
	public static void Main()
	{
		Console.WriteLine("Starting Execution...");

		string Base = Directory.GetCurrentDirectory().Replace(@"\", "/").Replace("/src/TexturePig.Generator/bin/Debug/net6.0", string.Empty);
		string Artifacts = Path.Combine(Base, "artifacts");
		string[] AllArtifacts = Directory.GetFiles(Artifacts);
		Console.WriteLine("\nbase: " + Base);
		Console.WriteLine("artifacts: " + Artifacts);
		foreach (string Artifact in AllArtifacts) 
		{
			var pack = Pack.FromJson(ConvertYamlToJson(File.ReadAllText(Artifact)));
			Console.WriteLine($"\nAdding: {pack.Name}, ID: {pack.Id}");
		}
	}

	static string ConvertYamlToJson(string yaml) 
	{
		var r = new StringReader(yaml);
		var deserializer = new Deserializer();
		var yamlObject = deserializer.Deserialize(r);
		return JsonConvert.SerializeObject(yamlObject);
	}
}