workspace {

    model {
        userHealthcareFacility = person "Healthcare facility user"
        systemHealthcareFacilityIdentity = softwareSystem "Healthcare Facility Identity" "Allows a user to authenticate" "Supporting System"
        systemCodesValidator = softwareSystem "Codes validator" "Allows diagnosis and medicine code validation" "Supporting System"
        systemEventBus = softwareSystem "Event bus" "Allows event-driven integration with other systems" "Supporting System"
        systemBlobs = softwareSystem "Blob storage" "Azure Blobs storage" "Supporting System"

        systemClaimsSubmission = softwareSystem "Claims submission" "Allows a Healthcare Facility user to upload and submit a batch file" {
            singlePageApplication = container "Single-Page Application" "Provides all of the upload and submission functionalities to healthcare facility via their web browser." "Angular" "Web Browser"
            apiApplication = container "API Application" "Provides upload and submission functionalities via a REST API." "ASP.NET Core API" {
                batchFilesController = component "Batch Files Controller" "Allows a healthcare facility to operate on batch files." "ASP.NET Core Controller"
                codesValidationFacade = component "Codes validation Facade" "Allows validating diagnosis and medicines code" "net6 library" 
                authorizationComponent = component "Authorization Component" "Allows authorizing a user." "OpenID Conect middleware"
                persistenceComponent = component "Persistence Component" "Allows to read and write from data store." "EF Core"
                fileStorageComponent = component "File Storage Component" "Allows to read and write files from Blobs." "net6 library"
                eventBusCompoenent = component "Event Bus Component" "Allows to send events into Bus" "net6 library"
            }
            database = container "Database" "Stores batch file processing related data" "SQL Server" "Database"
        }

        # relationships between people and software systems
        userHealthcareFacility -> systemClaimsSubmission "Uses"
        userHealthcareFacility -> systemHealthcareFacilityIdentity "Authenticates in"

        # relationships to/from containers
        userHealthcareFacility -> singlePageApplication "Manages batch files" "HTTPS"

        # relationships to/from components
        singlePageApplication -> batchFilesController "Makes API calls to" "REST/HTTPS"
        authorizationComponent -> systemHealthcareFacilityIdentity "Authorizes a user in"
        codesValidationFacade -> systemCodesValidator "Validates data bys uisng"
        eventBusCompoenent -> systemEventBus "Sends integration events to"
        fileStorageComponent -> systemBlobs "Stores files in"
        persistenceComponent -> database "Reads and writes data from/to"
    }

    views {
        systemContext systemClaimsSubmission "SystemContext" {
            include *
            animation {
                userHealthcareFacility 
                systemHealthcareFacilityIdentity 
                systemCodesValidator 
                systemEventBus 
                systemBlobs
            }
            autoLayout
        }

        container systemClaimsSubmission "Containers" {
            include *
            animation {
                userHealthcareFacility systemHealthcareFacilityIdentity   
                singlePageApplication
                apiApplication systemCodesValidator systemEventBus systemBlobs database
            }
            autoLayout
        }

        component apiApplication "Components" {
            include *
            animation {
                singlePageApplication 
                batchFilesController
                codesValidationFacade systemCodesValidator
                authorizationComponent systemHealthcareFacilityIdentity
                persistenceComponent database
                fileStorageComponent systemBlobs
                eventBusCompoenent systemEventBus
            }
            autoLayout
        }

        styles {
            element "Software System" {
                background #1168bd
                color #ffffff
            }
            element "Supporting System" {
                background #999999
                color #ffffff
            }
            element "Person" {
                shape person
                background #08427b
                color #ffffff
            }
            element "Container" {
                background #438dd5
                color #ffffff
            }
            element "Web Browser" {
                shape WebBrowser
            }
            element "Mobile App" {
                shape MobileDeviceLandscape
            }
            element "Database" {
                shape Cylinder
            }
            element "Component" {
                background #85bbf0
                color #000000
            }
        }
    }

}