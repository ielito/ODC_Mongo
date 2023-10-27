# MongoDB Integration Module for OutSystems

This module provides an integration between OutSystems and MongoDB, allowing developers to retrieve data from a MongoDB database and display it within an OutSystems application.

## Configuration

1. **Connection Settings**:
   - Update the `ConnectionString` and `DatabaseName` input parameters in the `GetCollectionDocuments` action to match your MongoDB setup.

2. **Collection Name**:
   - Specify the `CollectionName` input parameter in the `GetCollectionDocuments` action to target the desired MongoDB collection.

3. **Handling Data**:
   - Data retrieved from MongoDB will be formatted as JSON. Utilize OutSystems built-in JSON serialization and deserialization actions to work with the data.

## Usage

- Call the `GetCollectionDocuments` action from your OutSystems application to retrieve data from the specified MongoDB collection.
- Utilize the provided JSON to construct and display data in your application, or to further process and store it within OutSystems entities.

## Feedback

We appreciate your feedback! If you have suggestions or issues, please use the feedback option within the module to let us know.

## Future Improvements

- Enhanced data formatting options.
- Improved error handling.
- Additional actions for inserting and updating data in MongoDB.

## License

This module is licensed under the MIT License.
