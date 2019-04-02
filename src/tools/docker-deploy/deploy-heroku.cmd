call heroku container:login
call heroku container:push web -a qa-food-book
call heroku container:release web -a qa-food-book