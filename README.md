# ReceiptGenerator

This repo contains the solution to PROBLEM TWO Sales Taxes.

Tech stack used in this POC:
C#,
.NET Core API 6,
Unit test (XUnit),
Moq,
Dependency injection,
Serilog

The ReceiptGenerator.Api project contains the API level logics as well as the endpoint that is called to generate the receipt.

The ReceiptGenerator.Core holds the logic required to generate the receipt.

ReceiptGenerator.Test is a test project with some test cases.

After building the project, run the project ReceiptGenerator.Api from command line or in VS, the swagger ui should load automatically.


## API Overview

All responses are in the JSON format:
```
{
  "code": int,
  "status": string,
  "message": string,
  "data": object
}
```
The code contains the response code, status the response status, message a message, and data the response object.


## Endpoint

NOTE: authentication is not included in the project.

1. POST api/Receipt/generate: this is used to generate the receipt. It expect a list of items, each item object must have a name, quantity and price:

```
{
  "cartItems": [
    {
      "quantity": 2147483647,
      "name": "string",
      "price": 0
    }
  ]
}
```

The cartItems expect the list of items. 

A sample request using INPUT 1 of PROBLEM TWO in the test instruction is:
```
{
  "cartItems": [
    {
      "quantity": 1,
      "name": "Book",
      "price": 12.49
    },
   {
      "quantity": 1,
      "name": "Book",
      "price": 12.49
    },
   {
      "quantity": 1,
      "name": "Music CD",
      "price": 14.99
    },
   {
      "quantity": 1,
      "name": "Chocolate bar",
      "price": 0.85
    }
  ]
}
```

The request should give the response below:
```{
  "code": 200,
  "status": "success",
  "message": "Successful",
  "data": {
    "receipt": {
      "items": {
        "Book": 24.98,
        "Music CD": 16.49,
        "Chocolate bar": 0.85
      },
      "totalSalesTax": 1.5,
      "totalPrice": 42.32
    }
  }
}
```

The sample requests for INPUT 2 and 3:

```
{
  "cartItems": [
    {
      "quantity": 1,
      "name": "Imported box of chocolates",
      "price": 10.00
    },
    {
      "quantity": 1,
      "name": "Imported bottle of perfume",
      "price": 47.50
    }
  ]
}
```

```
{
  "cartItems": [
    {
      "quantity": 1,
      "name": "Imported bottle of perfume",
      "price": 27.99
    },
    {
      "quantity": 1,
      "name": "Bottle of perfume",
      "price": 18.99
    },
    {
      "quantity": 1,
      "name": "Packet of headache pills",
      "price": 9.75
    },
    {
      "quantity": 1,
      "name": "Imported box of chocolates",
      "price": 11.25
    },
    {
      "quantity": 1,
      "name": "Imported box of chocolates",
      "price": 11.25
    }
  ]
}
```

You can run other sample cases and evaluate the output.
