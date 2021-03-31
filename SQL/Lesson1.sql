Use BikeStore
/*Tất cả customers, sắp xếp theo thứ tự số lượng order họ mua từ cao đến thấp.*/
select distinct customer.first_name, customer.last_name, 
	sum(items.quantity) over (Partition by customer.customer_id) as QuantityOrders 
	from sales.customers as customer
	inner join sales.orders as orders on customer.customer_id = orders.customer_id
	inner join sales.order_items as items on items.order_id = orders.order_id
	order by QuantityOrders desc

/*Tất cả categories, và số lượng orders của từng category.*/
select distinct categories.category_name,
	Sum(items.quantity) over (Partition by categories.category_id) as QuantityOrders
	from production.products as products
	inner join production.categories as categories on products.category_id = categories.category_id
	inner join sales.order_items as items on items.product_id = products.product_id

/*Danh sách products sắp xếp theo số lượng order từ cao đến thấp.*/

select distinct products.product_name,
	sum(items.quantity) over (partition by products.product_id) as QuantityOrders
	from production.products as products
	inner join sales.order_items as items on items.product_id = products.product_id
	order by QuantityOrders desc

/*Danh sách cửa hàng, và các loại product đã được bán trong từng cửa hàng.*/

select distinct stores.store_name, products.product_name
	from production.stocks as stocks
	inner join sales.stores as stores on stocks.store_id = stores.store_id
	inner join production.products as products on stocks.product_id = products.product_id