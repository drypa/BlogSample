  declare @i int  = 0;
  while(@i<100)
  begin 
	insert into [dbo].[BlogPost] values (newid(),GETDATE(),'descr'+convert(varchar(3),@i),'text'++convert(varchar(3),@i),'title'++convert(varchar(3),@i))
	set @i+=1;
  end
  
  set @i = 0;
  declare @postId uniqueidentifier;
  while(@i<100)
  begin 
	select @postId = id from  [dbo].[BlogPost] order by newId();
	insert into [dbo].[Comment] values (NEWID(),GETDATE(),@postId,'comment text'+convert(varchar(3),@i))
	set @i+=1;
  end
  