# MongoDB Integration Module for OutSystems

This module provides an integration between OutSystems and MongoDB, enabling developers to perform CRUD (Create, Read, Update, Delete) operations from within an OutSystems application. It simplifies the interaction with MongoDB databases by providing a ready-to-use interface and server actions.

## Features

- **Seamless Integration**: Leverage the power of MongoDB directly within your OutSystems applications.
- **CRUD Operations**: Full set of operations to manage your MongoDB data with ease.
- **Flexible Configuration**: Set up connection strings and database configurations without writing any code.

## Getting Started

To begin using this module, clone the repository into your development environment, configure your database connection, and you're ready to start manipulating your MongoDB data through OutSystems.

### Prerequisites

- Access to an OutSystems environment.
- MongoDB server with proper credentials.

### Installation

To use in OutSystems: please look for this component on Forge.
To edit: Clone the GitHub repository to your local machine or directly into your OutSystems environment. Configure your MongoDB `connectionString` and `databaseName` through the Service Center or environment variables.

### Configuration

Set the `connectionString` and `databaseName` in the module settings to point to your MongoDB instance. This will be used across all server actions to establish a connection to the database.

## Usage

The module comes with pre-built screens that correspond to each CRUD operation:

- **Create**: Add new documents to your database using the intuitive web forms.
- **Read**: Search and retrieve documents with custom filters.
- **Update**: Apply changes to existing documents in your database.
- **Delete**: Remove documents from your collections as needed.

## Documentation

For detailed instructions on setting up and using this module, please refer to the [Documentation](/docs) folder.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE.md) file for details.

## Acknowledgments

- Hat tip to anyone whose code was used as inspiration.
- The OutSystems community for their continuous support.
- MongoDB team for providing an excellent NoSQL platform.
