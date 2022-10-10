Feature: FileUpload
	In order to submit a claims file
	As a Healthcare Facility authorized user
	I want to upload a file

Scenario: Upload a file
	Given the file "test1.json"
	When I request an upload
	Then I can see file has been uploaded successfully
	And I can see file validation has started