CREATE TABLE public."pokedex"(
    id INTEGER PRIMARY KEY,
    english_name TEXT NOT NULL UNIQUE,
    japanese_name TEXT NOT NULL,
    chinese_name TEXT NOT NULL,
    french_name TEXT NOT NULL,
    type_one TEXT NOT NULL,
    type_two TEXT,
    hp INTEGER NOT NULL,
    attack INTEGER NOT NULL,
    defence INTEGER NOT NULL,
    special_attack INTEGER NOT NULL,
    special_defence INTEGER NOT NULL,
    speed INTEGER NOT NULL
);