SET IDENTITY_INSERT dbo.[Users] ON

INSERT INTO dbo.[Users] (
  [Id]
  , [Username]
  , [Email]
  , [Key]
  , [Password]
  , [DisplayName]
  , [FirstName]
  , [MiddleName]
  , [LastName]
  , [IsDisabled]
  , [FailedLogins]
  , [UserType]
  , [IsVerified]
  , [VerifiedOn]
  , [CreatedBy]
  , [UpdatedBy]
) VALUES (
  1
  , 'admin'
  , 'admin@test.com'
  , '24e8ae15-848f-44ee-8a79-e014f89c538e'
  , ''
  , 'Administrator'
  , 'System'
  , ''
  , 'Administrator'
  , 0
  , 0
  , 0
  , 0
  , null
  -- Audit Columns
  , 'seed'
  , 'seed'
)

SET IDENTITY_INSERT dbo.[Users] OFF
