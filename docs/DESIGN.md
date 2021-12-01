# Design

The following explains the overall design of the Coevent solution.

## Audit Columns

All tables have the following audit columns.

| Column     | Type       | Size | Null | Constraint | Description                                              |
| ---------- | ---------- | ---- | ---- | ---------- | -------------------------------------------------------- |
| CreatedOn  | DATETIME2  |      |      |            | Date and time the record was created                     |
| CreatedBy  | NVARCHAR   | 50   |      |            | Username who created the record                          |
| UpdatedOn  | DATETIME2  |      |      |            | Date and time the record was updated                     |
| UpdatedBy  | NVARCHAR   | 50   |      |            | Username who updated the record                          |
| Rowversion | ROWVERSION |      |      |            | Rowversion or timestamp to enable optimistic concurrency |

## Authentication

Java Web Token (JWT) authentication provided by an email to identify each user.

## Authorization

Each user account has claims that provide access to various functions.

## User

A user is an authorized identity which can be associated to multiple accounts.
A user can be granted access to one or more account.
A user can become a participant within a given account.

| Column       | Type             | Size | Null | Constraint   | Description                                                           |
| ------------ | ---------------- | ---- | ---- | ------------ | --------------------------------------------------------------------- |
| Id           | INT              |      |      | PK, IDENTITY | Primary key to uniquely identify user within Coevent                  |
| Username     | NVARCHAR         | 50   |      | UNIQUE       | Unique friendly username to identify user within Coevent              |
| Email        | NVARCHAR         | 100  |      | UNIQUE       | Unique Email address to identify user within Coevent                  |
| Key          | UNIQUEIDENTIFIER |      |      | UNIQUE       | Unique key to identify user within and outside of Coevent             |
| DisplayName  | NVARCHAR         | 50   |      | UNIQUE       | Unique friendly name the user wants to display to others with Coevent |
| FirstName    | NVARCHAR         | 50   |      |              | First name of user                                                    |
| MiddleName   | NVARCHAR         | 50   | \*   |              | Middle name of user                                                   |
| LastName     | NVARCHAR         | 50   |      |              | Last name of user                                                     |
| IsDisabled   | BIT              |      |      |              | Whether the user is disabled                                          |
| FailedLogins | SMALLINT         |      |      |              | Number of failed login attempts                                       |
| UserType     | SMALLINT         |      |      |              | The type of user account [User, Participant]                          |
| IsVerified   | BIT              |      |      |              | Whether the account is verified                                       |
| VerifiedOn   | DATETIME2        |      | \*   |              | When the account was verified                                         |

### Participant

A participant is an 'unauthorized' identity which receives access through a UID which is managed within an account.
A participant is unique to an account, they cannot access multiple accounts.

Participants are users of type 'Participant'.

Participants allow for temporary keys to be handed out for new users to use Coevent without creating their own user accounts.
These can then be linked to a user account, a calendar, and a specific time period.

| Column     | Type      | Size | Null | Constraint   | Description                                                  |
| ---------- | --------- | ---- | ---- | ------------ | ------------------------------------------------------------ |
| Id         | BIGINT    |      |      | PK, IDENTITY | Primary key to uniquely identify user within Coevent         |
| UserId     | BIGINT    |      |      | FK           | Foreign key to the user account                              |
| CalendarId | INT       |      |      | FK           | Foreign key to the calendar they are invited to use          |
| TTL        | BIGINT    |      |      |              | Length of hours the invitation is good for                   |
| StartOn    | DATETIME2 |      | \*   |              | When the participant can start participating in the calendar |
| EndOn      | DATETIME2 |      | \*   |              | When the participant can start participating in the calendar |

## Account

Each account represents an organization that manages calendars, schedules, and participants.

| Column      | Type     | Size | Null | Constraint   | Description                                             |
| ----------- | -------- | ---- | ---- | ------------ | ------------------------------------------------------- |
| Id          | BIGINT   |      |      | PK, IDENTITY | Primary key to uniquely identify account within Coevent |
| Name        | NVARCHAR | 100  |      |              | The name of the account or organization                 |
| Description | NVARCHAR | 2000 | \*   |              | Description of the account                              |
| AccountType | SMALLINT |      |      |              | The type of account [Free, Subscriber]                  |
| IsDisabled  | BIT      |      |      |              | Whether the calendar is disabled                        |
| OwnerId     | INT      |      |      | FK           | Foreign key to the user who owns the account            |

## Calendar

A calendar provides a way to group and share schedules with users, and participants.

| Column       | Type     | Size | Null | Constraint   | Description                                              |
| ------------ | -------- | ---- | ---- | ------------ | -------------------------------------------------------- |
| Id           | INT      |      |      | PK, IDENTITY | Primary key to uniquely identify calendar within Coevent |
| AccountId    | BIGINT   |      |      | UX, FK       | Foreign key to the account who owns the calendar         |
| Name         | NVARCHAR | 100  |      | UX           | The name of the calendar                                 |
| Description  | NVARCHAR | 2000 | \*   |              | Description of the calendar                              |
| CalendarType | SMALLINT |      |      |              | The type of calendar                                     |
| IsDisabled   | BIT      |      |      |              | Whether the calendar is disabled                         |
| Status       | SMALLINT |      |      |              | The status of the calendar [Draft, Published, Cancelled] |

## Event

An event provides a way to identify a subset of time, and to group related schedules.
An event can be open to participants for registration.

| Column       | Type      | Size | Null | Constraint   | Description                                           |
| ------------ | --------- | ---- | ---- | ------------ | ----------------------------------------------------- |
| Id           | BIGINT    |      |      | PK, IDENTITY | Primary key to uniquely identify event within Coevent |
| Name         | NVARCHAR  | 100  |      |              | The name of the event                                 |
| Description  | NVARCHAR  | 2000 | \*   |              | Description of the event                              |
| EventType    | SMALLINT  |      |      |              | The type of event []                                  |
| IsDisabled   | BIT       |      |      |              | Whether the event is disabled                         |
| AccountId    | BIGINT    |      |      | FK           | Foreign key to the account who owns the event         |
| Status       | SMALLINT  |      |      |              | The status of the event [Draft, Published, Cancelled] |
| StartOn      | DATETIME2 |      |      |              | The start date and time                               |
| EndOn        | DATETIME2 |      |      |              | The end date and time                                 |
| ScheduleId   | BIGINT    |      | \*   | FK           | Foreign key to the schedule this event will follow    |
| DisplayOrder | INT       |      |      |              | Display the events in this order                      |

## Schedule

A schedule provides a way to manage when an event occurs.
An event can be repeated on a schedule, or only occur once.

| Column       | Type     | Size | Null | Constraint   | Description                                                         |
| ------------ | -------- | ---- | ---- | ------------ | ------------------------------------------------------------------- |
| Id           | BIGINT   |      |      | PK, IDENTITY | Primary key to uniquely identify schedule within Coevent            |
| AccountId    | BIGINT   |      |      | UX, FK       | Foreign key to the account who owns the schedule                    |
| Name         | NVARCHAR | 100  |      | UX           | The name of the schedule                                            |
| Description  | NVARCHAR | 2000 | \*   |              | Description of the schedule                                         |
| IsDisabled   | BIT      |      |      |              | Whether the schedule is disabled                                    |
| StartOnTime  | TIME2    |      |      |              | The start time                                                      |
| EndOnTime    | TIME2    |      |      |              | The end time                                                        |
| DaysOfWeek   | SMALLINT |      |      |              | The days of the week this schedule applies to                       |
| Months       | SMALLINT |      |      |              | The months this schedule applies to                                 |
| RepeatType   | SMALLINT |      |      |              | How this schedule repeats [Never, Daily, Weekly, Monthly, Annually] |
| RepeatSize   | SMALLINT |      |      |              | The increment for the repeat type (i.e. every second day)           |
| DisplayOrder | INT      |      |      |              | Display the schedules in this order                                 |

### Event Criteria

An opening criteria is a collection of traits that are required for the opening.

| Column     | Type   | Size | Null | Constraint | Description                 |
| ---------- | ------ | ---- | ---- | ---------- | --------------------------- |
| EventId    | BIGINT |      |      | PK, FK     | Foreign key to the event    |
| CriteriaId | BIGINT |      |      | PK, FK     | Foreign key to the criteria |
| TraitId    | BIGINT |      |      | PK, FK     | Foreign key to the trait    |

## Event Occurrence

An event occurrence provides a way to identify a function within an event and the scheduled time.
An event occurrence can be open to participants for registration.

| Column       | Type      | Size | Null | Constraint   | Description                                           |
| ------------ | --------- | ---- | ---- | ------------ | ----------------------------------------------------- |
| Id           | BIGINT    |      |      | PK, IDENTITY | Primary key to uniquely identify event within Coevent |
| EventId      | INT       |      |      | FK           | Foreign key to the event                              |
| Name         | NVARCHAR  | 100  |      |              | The name of the event                                 |
| Description  | NVARCHAR  | 2000 | \*   |              | Description of the event                              |
| IsDisabled   | BIT       |      |      |              | Whether the event is disabled                         |
| Status       | SMALLINT  |      |      |              | The status of the event [Draft, Published, Cancelled] |
| StartOn      | DATETIME2 |      |      |              | The start date and time                               |
| EndOn        | DATETIME2 |      |      |              | The end date and time                                 |
| DisplayOrder | INT       |      |      |              | Display the events in this order                      |

## Opening

An opening provides a way to identify an opportunity for one or more participant to apply.
Openings are linked to an event

| Column       | Type     | Size | Null | Constraint   | Description                                             |
| ------------ | -------- | ---- | ---- | ------------ | ------------------------------------------------------- |
| Id           | BIGINT   |      |      | PK, IDENTITY | Primary key to uniquely identify opening within Coevent |
| Name         | NVARCHAR | 100  |      |              | The name of the opening                                 |
| Description  | NVARCHAR | 2000 | \*   |              | Description of the opening                              |
| IsDisabled   | BIT      |      |      |              | Whether the opening is disabled                         |
| EventId      | BIGINT   |      |      | FK           | Foreign key to the owning event                         |
| DisplayOrder | INT      |      |      |              | Display the openings in this order                      |
| OpeningType  | SMALLINT |      |      |              | The type of opening []                                  |
| ApplyType    | SMALLINT |      |      |              | The application type [Application, Preapproved]         |
| Quantity     | INT      |      |      |              | Number of openings available                            |
| SurveyId     | BIGINT   |      | \*   |              | Foreign key to the survey                               |

## Opening Occurrence

An opening occurrence provides a way to identify an opportunity for one or more participant to apply.
Openings are linked to an event

| Column            | Type     | Size | Null | Constraint | Description                                                     |
| ----------------- | -------- | ---- | ---- | ---------- | --------------------------------------------------------------- |
| OpeningId         | BIGINT   |      |      | PK, FK     | Foreign key to the owning opening                               |
| EventOccurrenceId | BIGINT   |      |      | PK, FK     | Foreign key to the owning event occurrence                      |
| Status            | SMALLINT |      |      |            | The status of the opening [Draft, Published, Cancelled, Closed] |

### Opening Criteria

An opening criteria is a collection of traits that are required for the opening.

| Column     | Type   | Size | Null | Constraint | Description                 |
| ---------- | ------ | ---- | ---- | ---------- | --------------------------- |
| OpeningId  | BIGINT |      |      | PK, FK     | Foreign key to the opening  |
| CriteriaId | BIGINT |      |      | PK, FK     | Foreign key to the criteria |
| TraitId    | BIGINT |      |      | PK, FK     | Foreign key to the trait    |

## Application

When a participant wants to participate in an opening they apply.
An application can be automatically accepted on a first come first serve process, or it can be reviewed and approved.

| Column            | Type     | Size | Null | Constraint   | Description                                                     |
| ----------------- | -------- | ---- | ---- | ------------ | --------------------------------------------------------------- |
| Id                | BIGINT   |      |      | PK, IDENTITY | Primary key to uniquely identify application within Coevent     |
| UserId            | BIGINT   |      |      | FK           | Foreign key to the user who submitted                           |
| OpeningId         | BIGINT   |      |      | FK           | Foreign key to the owning opening                               |
| EventOccurrenceId | BIGINT   |      |      | FK           | Foreign key to the event occurrence                             |
| Status            | SMALLINT |      |      |              | The status of the opening [Submitted, Review, Approved, Denied] |

## Application Answer

An application answer is the response the participant enters to questions of surveys.

| Column     | Type     | Size | Null | Constraint | Description                 |
| ---------- | -------- | ---- | ---- | ---------- | --------------------------- |
| OpeningId  | BIGINT   |      |      | PK, FK     | Foreign key to the opening  |
| UserId     | INT      |      |      | PK, FK     | Foreign key to the user     |
| QuestionId | BIGINT   |      |      | PK, FK     | Foreign key to the question |
| Answer     | NVARCHAR | 2000 |      |            | The answer to the question  |

## Trait

An trait provides a way to identify what claims a participant requires for any given event or opening.

| Column      | Type     | Size | Null | Constraint   | Description                                                 |
| ----------- | -------- | ---- | ---- | ------------ | ----------------------------------------------------------- |
| Id          | BIGINT   |      |      | PK, IDENTITY | Primary key to uniquely identify application within Coevent |
| AccountId   | BIGINT   |      |      | UX, FK       | Foreign key to the account who owns the trait               |
| Name        | NVARCHAR | 50   |      | UX           | The name of the trait                                       |
| Description | NVARCHAR | 2000 | \*   |              | Description of the trait                                    |
| IsDisabled  | BIT      |      |      |              | Whether the trait is disabled                               |

## Criteria

A criteria provides a way to specify which claims are require to view an event and apply for openings.
A criteria can be applied to multiple different events and openings.

| Column      | Type     | Size | Null | Constraint   | Description                                              |
| ----------- | -------- | ---- | ---- | ------------ | -------------------------------------------------------- |
| Id          | BIGINT   |      |      | PK, IDENTITY | Primary key to uniquely identify criteria within Coevent |
| AccountId   | BIGINT   |      |      | UX, FK       | Foreign key to the account who owns the criteria         |
| Name        | NVARCHAR | 100  |      | UX,          | The name of the criteria                                 |
| Description | NVARCHAR | 2000 | \*   |              | Description of the criteria                              |

### Criteria Traits

A criteria trait is the actual requirements to be applied.

| Column     | Type     | Size | Null | Constraint | Description                                                                              |
| ---------- | -------- | ---- | ---- | ---------- | ---------------------------------------------------------------------------------------- |
| CriteriaId | BIGINT   |      |      | PK, FK     | Foreign key to the criteria                                                              |
| TraitId    | BIGINT   |      |      | PK, FK     | Foreign key to the trait                                                                 |
| Formula    | SMALLINT |      |      |            | The formula to apply to the trait [Equal, NotEqual, In, LessThan, GreaterThan, Between ] |
| Value      | NVARCHAR | 500  |      |            | The value the formula will compare the trait to                                          |
| IsRequired | BIT      |      |      |            | Whether this criteria is required                                                        |
| IsDisabled | BIT      |      |      |            | Whether the criteria is disabled                                                         |

## Claim

A claim provides a way to identify a user's ability, experience, skill, trait.

| Column      | Type     | Size | Null | Constraint   | Description                                                 |
| ----------- | -------- | ---- | ---- | ------------ | ----------------------------------------------------------- |
| Id          | BIGINT   |      |      | PK, IDENTITY | Primary key to uniquely identify application within Coevent |
| AccountId   | BIGINT   |      |      | UX, FK       | Foreign key to the account who owns the trait               |
| Name        | NVARCHAR | 50   |      | UX           | The name of the claim                                       |
| Description | NVARCHAR | 2000 | \*   |              | Description of the criteria                                 |

## User Claim

A claim provides a way to identify a user's ability, experience, skill, trait.

| Column    | Type     | Size | Null | Constraint | Description                                   |
| --------- | -------- | ---- | ---- | ---------- | --------------------------------------------- |
| UserId    | BIGINT   |      |      | PK, FK     | Foreign key to the owning user                |
| AccountId | BIGINT   |      |      | PK, FK     | Foreign key to the account who owns the trait |
| Name      | NVARCHAR | 50   |      | PK, FK     | The name of the claim                         |
| Value     | NVARCHAR | 100  |      |            | The value of the claim                        |

## Survey

A survey provides a way to request additional information for participants who are applying.

| Column      | Type     | Size | Null | Constraint   | Description                                                 |
| ----------- | -------- | ---- | ---- | ------------ | ----------------------------------------------------------- |
| Id          | BIGINT   |      |      | PK, IDENTITY | Primary key to uniquely identify application within Coevent |
| Name        | NVARCHAR | 100  |      |              | The name of the opening                                     |
| Description | NVARCHAR | 2000 | \*   |              | Description of the opening                                  |
| IsDisabled  | BIT      |      |      |              | Whether the opening is disabled                             |
| AccountId   | BIGINT   |      |      | FK           | Foreign key to the account who owns the criteria            |

## Survey Question

A survey question is asked to a participant who applies for an event or opening.

| Column       | Type     | Size | Null | Constraint   | Description                                                 |
| ------------ | -------- | ---- | ---- | ------------ | ----------------------------------------------------------- |
| Id           | BIGINT   |      |      | PK, IDENTITY | Primary key to uniquely identify application within Coevent |
| SurveyId     | BIGINT   |      |      | FK           | Foreign key to the owning survey                            |
| IsDisabled   | BIT      |      |      |              | Whether the opening is disabled                             |
| DisplayOrder | INT      |      |      |              | Display the openings in this order                          |
| Question     | NVARCHAR | 2000 |      |              | The question                                                |
| IsRequired   | BIT      |      |      |              | Whether this question is required                           |

## Role

A role is a group that a user belongs to. It provides claims.

| Column      | Type     | Size | Null | Constraint   | Description                                                 |
| ----------- | -------- | ---- | ---- | ------------ | ----------------------------------------------------------- |
| Id          | BIGINT   |      |      | PK, IDENTITY | Primary key to uniquely identify application within Coevent |
| AccountId   | BIGINT   |      |      | FK, UX       | Foreign key to the account who owns the criteria            |
| Name        | NVARCHAR | 100  |      | UX           | The name of the opening                                     |
| Description | NVARCHAR | 2000 | \*   |              | Description of the opening                                  |
| IsDisabled  | BIT      |      |      |              | Whether the opening is disabled                             |
