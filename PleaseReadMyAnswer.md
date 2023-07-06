# Assessment Finished By Manric Vilegas

## Task 1 [4 hours]

Dear Cate

I have finished second update about this project.
Please check it.

## Task 2 [2 hours]

- Design the User Interface (UI / UX):

Decide on the layout and appearance of the news section within the home tab.
Consider using a ListView or RecyclerView to display the news articles in a scrollable list.

- Fetching News Data:

Determine the source(s) from where I will retrieve the news data. This could be an API, RSS feed, or a content management system (CMS) if the client has one.
Implement the necessary logic to fetch news data from the chosen source(s).
Use libraries like Newtonsoft.Json or System.Net.Http for making HTTP requests and handling JSON data.
- Parse and Store News Data:

Receive the news data, parse it according to the provided format (JSON, XML, etc.).
Extract relevant information such as article title, description, publication date, and image URL.
Create a model class to represent the news articles and store this data in an appropriate data structure, such as a List<NewsItem>.
- Displaying News Articles:

Bind the list of news articles to the UI component (ListView/RecyclerView) to populate the view with the retrieved data.
Customize the item layout to display the relevant information, including the article title, description, and thumbnail image.
Handle user interaction events, such as tapping on a news article to open the full article or view more details.
- Periodic Content Updates:

To provide weekly or fortnightly updates, And It is needed to trigger the news data fetching periodically.
Schedule background tasks or use services like Firebase Cloud Messaging (FCM) to notify the app about new content availability.
Update the news data in the app's storage and refresh the UI accordingly.
- Caching and Offline Support:

Implement a caching mechanism to store previously fetched news articles on the device.
Consider using technologies like SQLite, Realm, or Xamarin.Essentials Preferences for local storage.
Enable offline support by allowing users to access previously loaded news articles when there is no internet connection.
- Error Handling and Exceptional Cases:

Implement appropriate error handling mechanisms to handle cases such as network failures, server errors, or parsing issues.
Show relevant error messages or fallback content when news data cannot be retrieved.
Provide an option for users to refresh the news section manually if necessary.