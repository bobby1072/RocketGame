CREATE TABLE public."user" (
    id UUID DEFAULT gen_random_uuid() PRIMARY KEY,
    email TEXT NOT NULL UNIQUE,
    name TEXT NOT NULL,
    date_created TIMESTAMP WITHOUT TIME ZONE DEFAULT now(),
    date_modified TIMESTAMP WITHOUT TIME ZONE DEFAULT now()
);