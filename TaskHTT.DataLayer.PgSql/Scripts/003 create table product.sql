create table enum_product
(
	id						serial not null primary key,
	product_name  			varchar(250) not null,
	title 					varchar(1000) not null,
	category_id				int not null,
	state_id				int not null,
	created_date			timestamp without time zone default now() not null,

	constraint fk_state_id foreign key ( state_id ) references enum_state ( id ),
	constraint fk_category_id foreign key ( category_id ) references enum_category ( id )
);
