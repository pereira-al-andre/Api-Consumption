# API Consumption
The primary goal here is to implement a straightforward request to the Rick and Morty animated series API and retrieve alien characters with an unknown status that appear in more than one episode of the series.

## Details
I opted for a simple implementation of a web API in .NET 7. I did not use multiple projects or tests. The request flow follows Controller > Service > Repository.

I applied the repository pattern. I like this pattern because it simplifies working with multiple data sources and organizes everything.

I implemented a straightforward caching mechanism using Microsoft's MemoryCache.
