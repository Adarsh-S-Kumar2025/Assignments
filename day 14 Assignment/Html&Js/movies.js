const movies = [
    { "MovieName": "The Great Adventure", "ActorName": "John Smith", "ReleaseDate": "2023-01-15" },
    { "MovieName": "Mystery in the Woods", "ActorName": "Emily Johnson", "ReleaseDate": "2022-09-28" },
    { "MovieName": "Love and Destiny", "ActorName": "Michael Brown", "ReleaseDate": "2023-05-02" },
    { "MovieName": "City of Shadows", "ActorName": "Sophia Williams", "ReleaseDate": "2023-03-12" },
    { "MovieName": "The Last Stand", "ActorName": "William Davis", "ReleaseDate": "2022-11-07" },
    { "MovieName": "Echoes of Time", "ActorName": "Olivia Wilson", "ReleaseDate": "2022-12-19" }
  ];
  
  // 1. List the movie name along with the actor name of those movies released in the year 2022
  const movies2022 = movies.filter(m => m.ReleaseDate.startsWith("2022"))
                            .map(m => ({ MovieName: m.MovieName, ActorName: m.ActorName }));
  console.log("Movies released in 2022:", movies2022);
  
  // 2. List the movie names released in the year 2023 where the actor is William Davis.
  const williamMovies2023 = movies.filter(m => m.ReleaseDate.startsWith("2023") && m.ActorName === "William Davis")
                                  .map(m => m.MovieName);
  console.log("Movies in 2023 with William Davis:", williamMovies2023);
  
  // 3. Retrieve the Actor name and release date of the movie “The Last Stand”
  const lastStand = movies.find(m => m.MovieName === "The Last Stand");
  console.log("The Last Stand details:", { ActorName: lastStand?.ActorName, ReleaseDate: lastStand?.ReleaseDate });
  
  // 4. Check whether there is any movie in the list with actor name “John Doe”
  const hasJohnDoe = movies.some(m => m.ActorName === "John Doe");
  console.log("Is John Doe present?", hasJohnDoe);
  
  // 5. Display the count of movies where the actor name is "Sophia Williams"
  const sophiaCount = movies.filter(m => m.ActorName === "Sophia Williams").length;
  console.log("Count of Sophia Williams movies:", sophiaCount);
  
  // 6. Insert an element{"MovieName": "The Final Stage","ActorName": "John Doe","ReleaseDate": "2022-08-11"}as last element
  movies.push({ "MovieName": "The Final Stage", "ActorName": "John Doe", "ReleaseDate": "2022-08-11" });
  console.log("After inserting The Final Stage:", movies);
  
  // 7. Check whether there exists any duplicate movie names present in the array
  const movieNames = movies.map(m => m.MovieName);
  const hasDuplicateNames = movieNames.length !== new Set(movieNames).size;
  console.log("Are there duplicate movie names?", hasDuplicateNames);
  
  // 8. Create a new array starting from the movie "City of Shadows"
  const startIndex = movies.findIndex(m => m.MovieName === "City of Shadows");
  const fromCityOfShadows = movies.slice(startIndex);
  console.log("Array starting from City of Shadows:", fromCityOfShadows);
  
  // 9. List the distinct actor names in array
  const distinctActors = [...new Set(movies.map(m => m.ActorName))];
  console.log("Distinct actor names:", distinctActors);
  
  // 10. Insert an element{"MovieName": "Rich & Poor","ActorName": "Johnie Walker","ReleaseDate": "2023-08-11"}as next element to movie “Love and Destiny”
  const loveIndex = movies.findIndex(m => m.MovieName === "Love and Destiny");
  movies.splice(loveIndex + 1, 0, { "MovieName": "Rich & Poor", "ActorName": "Johnie Walker", "ReleaseDate": "2023-08-11" });
  console.log("After inserting Rich & Poor:", movies);
  
  // 11. Display the count of distinct actor names in array
  const distinctActorCount = new Set(movies.map(m => m.ActorName)).size;
  console.log("Count of distinct actors:", distinctActorCount);
  
  // 12. Remove the movie named  "The Last Stand"
  const lastStandIndex = movies.findIndex(m => m.MovieName === "The Last Stand");
  if (lastStandIndex !== -1) movies.splice(lastStandIndex, 1);
  console.log("After removing The Last Stand:", movies);
  
  // 13. Check whether all the movies are released after 2021 Dec 31
  const allAfter20211231 = movies.every(m => new Date(m.ReleaseDate) > new Date("2021-12-31"));
  console.log("All movies after 2021-12-31?", allAfter20211231);
  
  // 14. Update movie named  "City of Shadows" ‘s release date as  "2023-03-13"
  const cityMovie = movies.find(m => m.MovieName === "City of Shadows");
  if (cityMovie) cityMovie.ReleaseDate = "2023-03-13";
  console.log("After updating City of Shadows:", movies);
  
  // 15. Create a new array of movie names whose movie name length is greater than 10.
  const longMovieNames = movies.filter(m => m.MovieName.length > 10).map(m => m.MovieName);
  console.log("Movie names with length > 10:", longMovieNames);
  