# P1PortfolioTechTest
### P1 Tech Test Example

This project was made with server side Blazor & Material Blazor. It allows the user to select up to 3 portfolios, and it will display the aggregated data of all 3. This includes:
* Aggregated Portfolio positions breakdown
* Aggregated Portfolio values
* Aggregated Payments information
* Aggregated Transfer information
* Aggergated Income information

Note that a date to/from is provided for this information - the Seccl API returns sometimes returns unusual data when adding to/from dates to porfolio reports, such as returning the same book & current value for a position, but also returning a non-zero growth. As the aim of the project was to represent aggregated data, the book/current values are what are used for calculation display, and not the pre-calculated growth percentages (plus aggregating percentages from multiple portfolios when positions could have different book values wouldn't make sense).

### Main endpoints used:

* List portfolio summaries: /portfolio/{firmId}
* Retreive portfolio report: /portfolio/report/{firmId}/{clientId}
* Retreive portfolio report with dates: /portfolio/report/{firmId}/{clientId}?toDate=YYYY-MM-DD&fromDate=YYYY-MM-DD

## Deployment:

To deploy, first the relevant credentials need to be added to appsettings.json. In something like Azure deployment, this would be done in a deployment transform. The required credentials are:

* API BaseUrl (for staging: http://pfolio-api-staging.seccl.tech)
* FirmId
* UserId
* Password

  After adding these, running the solution in VS should automatically open the blazor app in your default browser.
