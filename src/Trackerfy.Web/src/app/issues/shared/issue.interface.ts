export interface IssueInterface {
  "id": number,
  "summary": string,
  "issueTypeId": number,
  "issueTypeDescription": string,
  "issueStateId": number,
  "issueStateDescription": string,
  "createdBy": string,
  "created": Date,
  "lastModifiedBy": string,
  "lastModified": Date,
}
