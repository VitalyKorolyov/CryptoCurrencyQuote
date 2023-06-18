# Answers to Technical Questions

## 1. Time spent on the coding assignment
I spent around 12 hours on the coding assignment. If I had more time, I would consider adding the following improvements to the solution:
- Implementing proper error handling and exception logging for better fault tolerance. For example, I didn't handle all cases with API in CoinMarketCapApiClient.cs
- Improving validation in GetCryptoCurrencyQuoteQueryValidator to verify that a cryptocurrency code exists
- Adding integration tests to ensure robust code coverage. We can follow Microsoft documentation - https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-7.0
- Enhancing the API documentation and providing example requests and responses. As an option, we can integrate Swagger
- Adding authentification and authorization based on a JWT token.
- Improving CoinMarketCapApiClient to fetch all currencies in one request(it's limited of free plan, we can ask quote just for one currency)
- Adding rate limiter
- Using Redis instead of memory cache

# Notes:
- To run the request, please use the following URL http://localhost:5294/api/CryptoCurrency/BTC
- For the project's architecture, I took inspiration from this cool example - https://github.com/jasontaylordev/CleanArchitecture. However, I made some tweaks to match my own style and preferences. One thing I didn't quite like was the exception-based validation approach, so I decided to handle errors differently by using a custom Result object (Result.cs).
- I used chatGgt to generate unit tests

## 2. Most useful feature of c# 9 (Because c# 10 and c# 11 don't have useful features which change my programming style)
- One of the most useful features is the introduction of records (C# 9.0). I used them for dtos and queries

## 3. Performance issue in production
Here is steps which I usually follow: 
1. Identify the place of the problem using metrics (CPU, memory) and logs:
- Analyze CPU usage: Check which processes or threads are consuming the most CPU resources. Identify if any specific operations or functions are causing high CPU utilization.
- Monitor memory usage: Determine if there is excessive memory consumption or memory leaks that could impact performance.
- Review application logs: Look for any error messages, warnings, or exceptions that could indicate performance issues or bottlenecks.
2. If the issue is related to the database:
- Investigate query performance: Analyze the query execution plans and identify any potential performance bottlenecks, such as missing indexes, inefficient queries, or excessive data retrieval.
- Optimize database schema: Evaluate the database schema and make necessary optimizations, such as denormalization, indexing strategies, or partitioning.
- Monitor CPU and memory utilization of the database server: Ensure that the database server has sufficient resources and consider scaling up or out if necessary.
- Implement caching mechanisms: Introduce caching layers to reduce the frequency of database queries and improve response times.
3. If the issue is related to the code:
- Profile the code: Use profiling tools to identify sections of the code that are consuming the most CPU or memory resources. This can help pinpoint performance bottlenecks.
- Review algorithmic complexity: Analyze the algorithms used in the code and determine if there are more efficient alternatives available.
- Optimize database access: Minimize the number of database round-trips by optimizing database access patterns, such as batching operations, using bulk inserts, or optimizing data retrieval.
- Evaluate third-party dependencies: Check if any third-party libraries or components are causing performance issues. Consider alternative libraries or versions that provide better performance.
- Implement asynchronous operations: Utilize asynchronous programming techniques to improve responsiveness and utilize system resources more efficiently.

## 4. Latest technical book or tech conference
Well, in the past few years, I have been primarily focusing on improving my knowledge of algorithms through platforms like LeetCode. I have been actively solving algorithmic problems to enhance my problem-solving skills. Additionally, I have also invested time in enhancing my understanding of system design principles by completing relevant certification courses.

As for the latest technical book or tech conference, I haven't recently read any specific books, but I regularly follow technical blogs and resources from reputable companies such as Microsoft. These resources provide insights into the best practices and emerging technologies in the industry. By staying up-to-date with these blogs, I ensure that I remain informed about the latest trends and advancements in the field.

## 5. Thoughts on the technical assessment
I found the technical assessment to be a valuable exercise. It allowed me to demonstrate my skills and knowledge in various areas.

## 6. Description of myself using JSON
{
"name": "Vitali Karaliou",
"occupation": "Senior Software Engineer",
"experienceOfYears": "8",
"skills": ["C#", "ASP.NET Core", "SQL", "Algorithms and data structures"],
"interests": ["Programming", "Travelling"],
"education": "Master of Computer Science"
}
