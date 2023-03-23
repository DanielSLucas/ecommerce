CREATE TABLE [dbo].[user]
(
    [id]       INT            NOT NULL PRIMARY KEY      IDENTITY (1, 1),
    [name]     NVARCHAR (150) NOT NULL,
    [cpf]      NVARCHAR (11)  NOT NULL,
    [tel]      NCHAR (11)     NOT NULL,
    [is_adm]   BIT            NOT NULL,
    [password] NCHAR (10)     NOT NULL,
    [email]    NVARCHAR (50)  NOT NULL
);

CREATE TABLE [dbo].[address] (
    [id]       INT          NOT NULL    PRIMARY KEY     IDENTITY (1, 1),
    [cep]      NVARCHAR (8) NOT NULL,
    [number]   NCHAR (10)   NOT NULL,
    [street]   NCHAR (10)   NOT NULL,
    [district] NCHAR (10)   NOT NULL,
    [city]     NCHAR (10)   NOT NULL,
    [uf]       NCHAR (10)   NOT NULL,
    [user_id]  INT          NOT NULL,
    CONSTRAINT FK_USER_ADDRESS FOREIGN KEY ([user_id]) REFERENCES [dbo].[user]([id])
);

CREATE TABLE [dbo].[product] (
    [id]          INT             NOT NULL  PRIMARY KEY     IDENTITY (1, 1),
    [name]        NVARCHAR (100)  NOT NULL,
    [description] TEXT            NOT NULL,
    [price]       DECIMAL (10, 2) NOT NULL    
);

CREATE TABLE [dbo].[category] (
    [id]          INT             NOT NULL  PRIMARY KEY     IDENTITY (1, 1),
    [name]        NVARCHAR (50)   NOT NULL    
);

CREATE TABLE [dbo].[product_category] (
    [id]           INT           NOT NULL  PRIMARY KEY     IDENTITY (1, 1),
    [product_id]   INT           NOT NULL,
    [category_id]  INT           NOT NULL,
    CONSTRAINT     FK_PRODUCT_CATEGORY FOREIGN KEY ([product_id]) REFERENCES [dbo].[product]([id]),
    CONSTRAINT     FK_CATEGORY_PRODUCT FOREIGN KEY ([category_id]) REFERENCES [dbo].[category]([id])    
);

CREATE TABLE [dbo].[product_image] (
    [id]          INT             NOT NULL  PRIMARY KEY     IDENTITY (1, 1),
    [filename]    NVARCHAR (50)   NOT NULL,
    [product_id]  INT             NOT NULL,
    CONSTRAINT    FK_PRODUCT_IMAGE FOREIGN KEY ([product_id]) REFERENCES [dbo].[product]([id]),
);

CREATE TABLE [dbo].[cart] (
    [id]          INT          NOT NULL    PRIMARY KEY     IDENTITY (1, 1),    
    [is_active]   BIT          NOT NULL,
    [user_id]     INT          NOT NULL,
    CONSTRAINT FK_USER_CART FOREIGN KEY ([user_id]) REFERENCES [dbo].[user]([id])
);

CREATE TABLE [dbo].[cart_product] (
    [id]            INT             NOT NULL  PRIMARY KEY     IDENTITY (1, 1),
    [cart_id]       INT             NOT NULL,
    [product_id]    INT             NOT NULL,
    CONSTRAINT      FK_CART_PRODUCT FOREIGN KEY ([cart_id]) REFERENCES [dbo].[cart]([id]),
    CONSTRAINT      FK_PRODUCT_CART FOREIGN KEY ([product_id]) REFERENCES [dbo].[product]([id])    
);

CREATE TABLE [dbo].[order] (
    [id]       INT           NOT NULL  PRIMARY KEY     IDENTITY (1, 1),
    [date]     DATETIME      NOT NULL  DEFAULT         CURRENT_TIMESTAMP,
    [status]   NVARCHAR (50) NULL,
    [cart_id]  INT           NOT NULL,
    CONSTRAINT FK_CART_ORDER FOREIGN KEY ([cart_id]) REFERENCES [dbo].[cart]([id]),    
);
