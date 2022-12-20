docker-compose -f docker-compose.yml up -d 
Write-Output "--------------------------------------------------------------------------------------"
Write-Output "Load testing with Grafana dashboard http://localhost:3000/d/k6/k6-load-testing-results"
Write-Output "--------------------------------------------------------------------------------------"
k6 run /scripts/script.js --out json=test.json --out influxdb=http://localhost:8086/k6 