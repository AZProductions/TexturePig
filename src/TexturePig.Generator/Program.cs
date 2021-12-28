﻿

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
		string OutputCDN = Path.Combine(Base, "output").ToString() + "/cdn/";
		string OutputStatic = Path.Combine(Base, "output").ToString()+ "/static/";

		string[] AllArtifacts = Directory.GetFiles(Artifacts);
		Console.WriteLine("\nbase: " + Base);
		Console.WriteLine("artifacts: " + Artifacts);
		foreach (string Artifact in AllArtifacts) 
		{
			var pack = Pack.FromJson(ConvertYamlToJson(File.ReadAllText(Artifact)));
			Console.WriteLine($"\nAdding: {pack.Name}, ID: {pack.Id}");
			File.WriteAllText(OutputStatic+"/pack/" + $"{pack.Name}.html", PackPage(pack));
		}
		File.WriteAllText(OutputCDN + $"index.html", RedirectPage("https://texturepig.com/"));
	}

	static string ConvertYamlToJson(string yaml) 
	{
		var r = new StringReader(yaml);
		var deserializer = new Deserializer();
		var yamlObject = deserializer.Deserialize(r);
		return JsonConvert.SerializeObject(yamlObject);
	}

	static string RedirectPage(string URL) 
	{
		return $"<!DOCTYPE html><html><head><meta http-equiv=\"refresh\" content=\"0; URL = {URL}\" /></head><body><p>If you are not redirected in five seconds, <a href=\"{URL}\">click here</a>.</p></body></html>";
	}

	static string PackPage(Pack pack) 
	{
		return $"<!DOCTYPE html><html lang=\"en\"><head><meta charset=\"utf-8\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0, shrink-to-fit=no\"><title>{pack.Name} - TexturePig</title><meta name=\"twitter:image\" content=\"https://texturepig.com/assets/img/icons/output500.png\"><meta property=\"og:image\" content=\"https://texturepig.com/assets/img/icons/output.png\"><meta name=\"description\" content=\"Download {pack.Name} now at TexturePig for free in a matter of seconds. For version {pack.Version}. {pack.Description}\"><link rel=\"icon\" type=\"image/svg+xml\" sizes=\"500x500\" href=\"/assets/img/icons/favicon.svg\"><link rel=\"icon\" type=\"image/svg+xml\" sizes=\"500x500\" href=\"/assets/img/icons/favicon.svg\"><link rel=\"icon\" type=\"image/svg+xml\" sizes=\"500x500\" href=\"/assets/img/icons/favicon.svg\"><link rel=\"icon\" type=\"image/svg+xml\" sizes=\"500x500\" href=\"/assets/img/icons/favicon.svg\"><link rel=\"icon\" type=\"image/svg+xml\" sizes=\"500x500\" href=\"/assets/img/icons/favicon.svg\"><link rel=\"stylesheet\" href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css\"><link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Montserrat&amp;display=swap\"><link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Poppins&amp;display=swap\"><link rel=\"stylesheet\" href=\"https://fonts.googleapis.com/css?family=Roboto&amp;display=swap\"><link rel=\"stylesheet\" href=\"https://use.fontawesome.com/releases/v5.12.0/css/all.css\"><link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css\"><link rel=\"stylesheet\" href=\"/assets/fonts/fontawesome5-overrides.min.css\"><link rel=\"stylesheet\" href=\"/assets/css/footer.css\"><link rel=\"stylesheet\" href=\"/assets/css/nav.css\"><link rel=\"stylesheet\" href=\"/assets/css/styles.css\"></head><body><nav class=\"navbar navbar-light navbar-expand-md sticky-top navigation-clean\" style=\"box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);backdrop-filter: blur(5px);-webkit-backdrop-filter: blur(5px);border: 1px solid rgba(255, 255, 255, 0.3);\"><div class=\"container-fluid\"><a class=\"navbar-brand\" href=\"#\"><img src=\"/assets/img/icons/favicon.svg\" style=\"width: 50px;height: 50px;margin-left: 15px;pointer-events: none;\" draggable=\"false\" dragstart=\"false;\" alt=\"TexturePig Logo\"></a><a class=\"navbar-brand\" href=\"#\" style=\"font-family: Poppins, sans-serif;font-weight: 600;\">TexturePig</a><button data-bs-toggle=\"collapse\" class=\"navbar-toggler\" data-bs-target=\"#navcol-2\"><span class=\"visually-hidden\">Toggle navigation</span><span class=\"navbar-toggler-icon\"></span></button><div class=\"collapse navbar-collapse\" id=\"navcol-2\"><ul class=\"navbar-nav ms-auto\"><li class=\"nav-item\" style=\"text-align: center;font-family: Poppins, sans-serif;\"><a class=\"nav-link active\" href=\"/index.html\">Home</a></li><li class=\"nav-item\" style=\"text-align: center;font-family: Poppins, sans-serif;\"><a class=\"nav-link\" href=\"categories.html\">Categories</a></li><li class=\"nav-item\" style=\"text-align: center;font-family: Poppins, sans-serif;\"><a class=\"nav-link\" href=\"downloads.html\">Downloads</a></li><li class=\"nav-item dropdown\" style=\"text-align: center;font-family: Poppins, sans-serif;\"><a class=\"dropdown-toggle nav-link\" aria-expanded=\"false\" data-bs-toggle=\"dropdown\" href=\"#\" style=\"margin-right: 13px;\">More</a><div class=\"dropdown-menu\" style=\"margin-top: 11px;border-style: none;box-shadow: 0px 0px 11px 0px rgba(33,37,41,0.45);\"><a class=\"dropdown-item\" href=\"#\"><i class=\"fa fa-bed\" style=\"font-size: 16px;margin-right: 10px;\"></i>Bedwars</a><a class=\"dropdown-item\" href=\"#\"><i class=\"fa fa-superpowers\" style=\"font-size: 16px;margin-right: 10px;\"></i>Skywars</a><a class=\"dropdown-item\" href=\"#\"><i class=\"fa fa-snowflake-o\" style=\"font-size: 16px;margin-right: 10px;\"></i>UHC</a><div class=\"dropdown-divider\"></div><a class=\"dropdown-item\" href=\"https://status.texturepig.com\" target=\"_blank\"><i class=\"fa fa-server\" style=\"font-size: 16px;margin-right: 10px;\"></i>Status</a><a class=\"dropdown-item\" href=\"#\"><i class=\"fa fa-support\" style=\"font-size: 16px;margin-right: 10px;\"></i>Support</a><a class=\"dropdown-item\" href=\"#\"><i class=\"fa fa-info-circle\" style=\"font-size: 16px;margin-right: 10px;\"></i>About us</a></div></li></ul></div><a class=\"btn btn-light\" role=\"button\" href=\"upload.html\" style=\"background: rgba(255, 255, 255, 0.2);border-radius: 16px;box-shadow: 0 4px 30px rgba(0, 0, 0, 0.1);backdrop-filter: blur(5px);-webkit-backdrop-filter: blur(5px);border: 1px solid rgba(255, 255, 255, 0.3);\">Upload</a></div></nav><div class=\"container my-5\"><div class=\"row p-4 pb-0 pe-lg-0 pt-lg-5 align-items-center rounded-3 border shadow-lg\"><div class=\"col-lg-7 p-3 p-lg-5 pt-lg-3\"><h1 class=\"display-4 fw-bold\">{pack.Name}</h1><p class=\"lead\">{pack.Description} [{pack.Version}]</p><div class=\"d-grid gap-2 d-md-flex justify-content-md-start mb-4 mb-lg-3\"><a class=\"btn btn-primary btn-lg px-4 me-md-2 fw-bold\" role=\"button\" href=\"{pack.Url}\">Download</a></div></div><div class=\"offset-lg-2 p-0 overflow-hidden shadow-lg\" style=\"height: 128px;width: 128px;margin-bottom: 50px;background: rgba(255, 255, 255, 0.2);border-radius: 16px;backdrop-filter: blur(5px);-webkit-backdrop-filter: blur(5px);border: 1px solid rgba(255, 255, 255, 0.3);pointer-events: none;\"><img class=\"rounded-lg-3\" src=\"{pack.Image}\" style=\"width: 128px;height: 128px;\"></div></div></div><footer class=\"footer-basic\" style=\"background: rgba(255,255,255,0);\"><div class=\"social\"><a href=\"https://www.youtube.com/channel/UC1LDuTWObE6GubnrvWAVgOQ\"><i class=\"fab fa-youtube\"></i></a><a href=\"https://github.com/AZProductions/TexturePig/\"><i class=\"fab fa-github\"></i></a><a href=\"https://twitter.com/PigpotYT\"><i class=\"fab fa-twitter\"></i></a><a href=\"https://www.twitch.tv/pigpotlive\"><i class=\"fab fa-twitch\"></i></a><a href=\"https://discord.com/invite/n3z8VXYmm6\"><i class=\"fab fa-discord\"></i></a></div><ul class=\"list-inline\" style=\"font-family: Poppins, sans-serif;\"><li class=\"list-inline-item\"><a href=\"#\">Home</a></li><li class=\"list-inline-item\"><a href=\"#\">Categories</a></li><li class=\"list-inline-item\"><a href=\"/index.html\">About</a></li><li class=\"list-inline-item\"><a href=\"#\">Terms</a></li><li class=\"list-inline-item\"><a>Privacy Policy</a></li></ul><p class=\"copyright\" style=\"font-family: Poppins, sans-serif;\">TexturePig By Pigpot © 2021</p></footer><script src=\"https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js\"></script></body></html>";
	}
}