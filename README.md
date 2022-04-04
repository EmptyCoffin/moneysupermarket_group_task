# Moneysupermarket group - Price Calculation Exercise - Jamie Hayes

The purpose of the application is to provide correct price that a customer should pay given the items in their basket and the current offers available

Unit/Integration tests were used to verify the functionality of the application

A Singeton pattern was used for defining and accessing the current offers as I believe offers would be updated/added from another part of the application, but this exercise was on the use of the offers

The application was written in C# in Visual Studio Code (v1.66.0) with the following extensions; .NET Core Test Explorer (v0.7.7), C# (v1.24.3), C# Extensions (v1.3.1)

## Future work

- I would want to utilise a database to store products to not need a new class per product
- I would also like to introduce a feedback to the end user that would alert them to any missed offers they might not of been aware of (i.e. buying 3 milk and not having a 4th in their basket missing an opportunity)
- Further onto that feedback system it would be good to have a sub total with the overall original price, the amount saved through offers and then the actual price so the user would be able to see a lot more detailed information