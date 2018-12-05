docker stop $(docker ps -a -q)
docker rm $(docker ps -a -q)
docker rmi $(docker images --filter=reference='modern*:latest' -q)
docker system prune --volumes -f