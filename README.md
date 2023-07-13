# Assessment

## Task 1 [4 hours]
This is a start-template project in Xamarin.Forms. The goal of the first task is to assess your skills in coding practices and code- management practices.


## Changes:
1. Create a new tab in the application

2.  Create two buttons in the new tab that will each invoke an endpoint in our API. The endpoints have anonymous access and do not require authentication. Mentioned endpoints are
 * https://malkarakundostagingpublicapi.azurewebsites.net/success
 * https://malkarakundostagingpublicapi.azurewebsites.net/fail

When response is received – show an alert popup with result (error message for errors, success message for successful calls).

3. Create a button to the new tab in top corner that will open up a form to ask for User’s name & age. When data is submitted, display collected information textually in created tab (above the buttons created before). Only show the User data fields when information has been entered.

#### Your task is to create a fork of the project, prepare the changes and create a pull request. 
#### You should not spend more than 4 hours on the task. If you have time left over in your task, feel free to showcase your skills & include features to the views.



## Task 2 [2 hours]

The Undo stack consists of web services mainly in Azure, Web API, Admin panel & Xamarin.Forms application. Take a look at the home tab of the Undo application, read through the letter from the client and write us a proposed solution and prepare questions that will help you understand the task better in detail and to make better choices when deciding for the solution.

Letter from client: “We want to have a new feature in the application’s home tab – a news section. The news section’s goal will be providing news to users using the application, where we would be posting content weekly or fortnightly.”

For questions, please contact Cate (cate@undoapp.com)

### Task 2 answer
1) What is the expected news structure? Please review the sample structure provided and make any necessary changes according to your expectations.

A news item should include the following:

Title (required)
News picture (optional)
Short description (optional)
Time to read (optional)
Date (optional)
Tag/tags (optional)
Full description (required)

2) If a news picture is optional and not provided, the mobile app can use a default placeholder picture, such as a black word "News" on a white background, etc.

3) Based on the news structure, the section can be displayed in several UI options. Considering the current home screen approaches that have been implemented, the news will be presented as a horizontal scroll section. We can reuse some of the UI approaches, such as Body Bundle, Reset Meditation, Deep Meditation, Talks, and Blogs. If you have specific UI requirements, please choose a section to use as a base. Otherwise, provide information on how the news cards should look.

4) If you have any special requests, we need to know the form factor of the news cards, the title position (under the picture or over it), and the position of the short description, if needed.
 
5) Should additional information be displayed on the news card, such as date, tags, time to read,  marked as new,  etc.? 

6) Do we need any actions on the news card, such as share, hide, mark as read,favorite, etc.?

7) For the news details screen, if you expect it to be a full-screen page in the app, we need to know the UI expectations. From our perspective, it would be most convenient to reuse the Blogs details screen as the base UI. If this is not suitable, please provide a list of required items that should be displayed and their order. For example: title, short description, date and time to read on one line, options to add to favorites and share, tags, and full text. Should there be options to mark as read or mark as new?

8) Where should the news section be positioned relative to the existing sections?

9) What should be the news ordering behavior? Should the news be sorted from newest to oldest? Do we need any subgroups based on categories like marked as read, favorites, tags, etc.? If so, what should be the ordering of the subgroups?
