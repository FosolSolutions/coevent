SET IDENTITY_INSERT dbo.[Accounts] ON

INSERT INTO dbo.[Accounts] (
  [Id]
  , [Name]
  , [Description]
  , [AccountType]
  , [IsDisabled]
  , [OwnerId]
  , [CreatedBy]
  , [UpdatedBy]
) VALUES (
  1
  , 'Coevent'
  , ''
  , 0
  , 0
  , 1
  -- Audit Columns
  , 'seed'
  , 'seed'
)

SET IDENTITY_INSERT dbo.[Accounts] OFF
