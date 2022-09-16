
# Hi, I'm Haythem 👋 and this is RateMyAnime 🍜! 


## 🚀 About Me
I'm a full stack developer intrested in microsoft stack, js frameworks and all that jazz 🎷...


## 🌐 About the project
This project is my way of discovering the [minimal api](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis) 
which is a new feature allowing .Net programmers to write apis with minimal dependencies. \
In my opinion, when combined with .Net 6 new features it's more like the Python way of doing things (at least Flask).
\
The idea is simple. I used an Api called [Jikan](https://docs.api.jikan.moe/) (which means *time* ⌛ in japanese in case you don't know) to get an Anime by its name (or a random one) and then calculate the rating based on the scores of the episodes. 
## Tech Stack

**[Carter](https://github.com/CarterCommunity/Carter) :** I used the Carter template, which made things well organized but it still requires a lot of config (appSettings, Swagger ...) if you opt for something more complex. 

**[RestSharp](https://restsharp.dev/) :** A great substitute for the default HttpClient.


## Installation

Install my-project with npm

<pre>
git clone <b>Project_URL</b>
</pre>

```bash
    cd RateMyAnime
    dotnet run
```
## API Reference

#### Get a random Anime and calculate it's score

```http
  GET /api/randomScore
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `no param` |         | Might take sometime because not all<br/>random results have a score |

#### Get item

```http
  GET /api/animeScore?animeName=${animeName}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `animeName`      | `string` | **Required**. Name of the Anime to get it's score |

#### GetScoreFromEpisodesAsync(id)

Get the score of the specified Anime id based on the score of it's episodes.


## Acknowledgements

 - [Readme.so](https://readme.so/) : An awesome Readme Editor 
 - [RapidAPI](https://rapidapi.com/hub) : Allows you to find, connect and manage multiple APIs
 - [Json2csharp](https://json2csharp.com/) : Convert any JSON object to a C# class online.
