create table enum_category
(
	id						serial not null primary key,
	category_name  			varchar(250) not null,
	title					varchar(1000) not null,
	state_id				int not null,
	created_date			timestamp without time zone default now() not null,

	constraint fk_state_id foreign key ( state_id ) references enum_state ( id )
);
