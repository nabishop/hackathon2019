use slohacks;

create table users(
name varchar(30) not null,
password varchar(30) not null,
user_id int unsigned not null auto_increment primary key
);

create table playlists(
name varchar(30) not null,
vibe varchar(30) not null,
date_added timestamp not null default current_timestamp,
song_id int unsigned not null,
user_id int unsigned not null,
primary key(user_id, name, song_id)
);

create table songs(
name varchar(30) not null,
genre varchar(30) not null,
length time not null,
album_covers varchar(30) not null,
artist varchar(30) not null,
song_id int unsigned not null auto_increment primary key
);

create table users(
name varchar(30) not null,
password varchar(30) not null,
user_id int unsigned not null auto_increment primary key
)
