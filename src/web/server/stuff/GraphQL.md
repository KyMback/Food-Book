# Review GraphQL

### Typing
```json
query test($from: Int!, $count: Int!, $title: String) {
```
```Int!``` It is **not nullable** type. You **can't** skip it in query definition

```String``` It is **nullable** type. You **can** skip it in query definition

Difference in existence ```!``` in the end of type

### Arguments
```json
recipes(from: $from, count: $count, title: $title)
```
Here you can see arguments which will be send to the server and possibly will be used for filtering

# Recipes

## Retrieve plural recipes
```json
{
  "Query": "query test($from: Int!, $count: Int!, $title: String, $ownerId: String) {
      recipes(from: $from, count: $count, title: $title, ownerId: $ownerId) {
          entities {
            id
            title
            ingredients
            createdBy
            createdOn
          }
          count
      }
  }",
  "Variables": {
      "from": 0,
      "count": 10,
      "title": "test",
      "ownerId": "55c29e8f-2c4a-41aa-abd1-83f6ec8a77d4"
  }
}
```

## Retrieve single recipe
```json
{
    "Query": "query test($id: String!) {
        recipe(id: $id) {
            id
            title
            ingredients
            createdBy
            createdOn
        }
    }",
    "Variables": {
        "id": "4ec40d3f-5d4e-4f9b-81a2-e0e3ab337913"
    }
}
```