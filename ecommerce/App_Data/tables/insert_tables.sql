INSERT INTO [dbo].[product] ([slug], [name], [description], [price])
VALUES
('iphone-13', 'iPhone 13', 'O iPhone 13 � o mais recente smartphone da Apple', 799.00),
('macbook-pro-2021', 'MacBook Pro 2021', 'O novo MacBook Pro 2021 da Apple � equipado com o chip M1 Pro ou M1 Max', 1999.00),
('airpods-pro', 'AirPods Pro', 'AirPods Pro s�o fones de ouvido sem fio com cancelamento de ru�do ativo', 249.00);

INSERT INTO [dbo].[category] ([name])
VALUES
('Smartphones'),
('Computadores'),
('Acess�rios');

INSERT INTO [dbo].[product_category] ([product_id], [category_id])
VALUES
(1, 1),
(2, 2),
(3, 3);