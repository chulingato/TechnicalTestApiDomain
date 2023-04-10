# TechnicalTestApi.Domain

API for managing products and sale orders, using Hexagonal architecture, Database is created automatically at running TechnicalTestApi.Domain project.
Based on Backend technical test provided by Sitec

## Endpoints

### GET /api/SaleOrder

Returns a list of all sale orders.

#### Response

- Status code: 200 OK
- Content type: application/json
```json
[
{
"saleOrderId": "string",
"saleOrderNumber": "integer",
"date": "string",
"description": "string",
"subtotal": "decimal",
"tax": "decimal",
"total": "decimal",
"annulled": "boolean",
"saleOrderDetail": [
{
"saleOrderDetailId": "string",
"quantity": "integer",
"price": "decimal",
"total": "decimal",
"productId": "string",
"productName": "string"
}
]
}
]
```


### GET /api/SaleOrder/{id}

Returns a single sale order by ID.

#### Parameters

- id (required): The ID of the sale order.

#### Response

- Status code: 200 OK
- Content type: application/json

```json
{
"saleOrderId": "string",
"saleOrderNumber": "integer",
"date": "string",
"description": "string",
"subtotal": "decimal",
"tax": "decimal",
"total": "decimal",
"annulled": "boolean",
"saleOrderDetail": [
{
"saleOrderDetailId": "string",
"quantity": "integer",
"price": "decimal",
"total": "decimal",
"productId": "string",
"productName": "string"
}
]
}
```


### POST /api/SaleOrder

Creates a new sale order.

#### Request body
```json
{
"saleOrderId": "string",
"saleOrderNumber": "integer",
"date": "string",
"description": "string",
"subtotal": "decimal",
"tax": "decimal",
"total": "decimal",
"annulled": "boolean",
"saleOrderDetail": [
{
"saleOrderDetailId": "string",
"quantity": "integer",
"price": "decimal",
"total": "decimal",
"productId": "string",
"productName": "string"
}
]
}
```


#### Response

- Status code: 200 OK
- Content type: text/plain

### DELETE /api/SaleOrder/{id}

Deletes a sale order by ID.

#### Parameters

- id (required): The ID of the sale order.

## API Documentation

### GET /api/Product

Retrieve all products.

#### Response

- 200 OK - List of products.

### GET /api/Product/{id}

Retrieve a product by ID.

#### Parameters

- `id` - The ID of the product to retrieve.

#### Response

- 200 OK - The requested product.
- 404 Not Found - The requested product does not exist.

### POST /api/Product

Add a new product.

#### Request Body

- `name` - The name of the product.
- `description` - The description of the product.
- `cost` - The cost of the product.
- `price` - The price of the product.
- `stock` - The stock of the product.

```json
{
  "name": "Escoba pa barrer",
  "description": "es una escoba verde",
  "cost": 10.0,
  "price": 20.0,
  "stock": 50.0
}
```

#### Response

- 200 OK - The product has been added.

### PUT /api/Product/{id}

Edit an existing product.

#### Parameters

- `id` - The ID of the product to edit.

#### Request Body

- `name` - The name of the product.
- `description` - The description of the product.
- `cost` - The cost of the product.
- `price` - The price of the product.
- `stock` - The stock of the product.

```json
{
  "name": "nombre de escoba actualizada",
  "description": "ahora es una escoba roja",
  "cost": 12.0,
  "price": 25.0,
  "stock": 60.0
}
```

#### Response

- 200 OK - The product has been edited.
- 404 Not Found - The requested product does not exist.

### DELETE /api/Product/{id}

Delete an existing product.

#### Parameters

- `id` - The ID of the product to delete.

