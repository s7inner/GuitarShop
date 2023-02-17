USE [elibraryDB]
GO

INSERT INTO [dbo].[member_master_tbl]
           ([full_name]
           ,[dob]
           ,[contact_no]
           ,[email]
           ,[state]
           ,[city]
           ,[pincode]
           ,[full_address]
           ,[member_id]
           ,[password]
           ,[account_status])
     VALUES
          ('test','4323','4323','123@gmail.com','state','city','344','full address','test','test','pending')
GO

