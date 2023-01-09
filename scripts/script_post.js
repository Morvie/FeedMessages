import http from 'k6/http';
import { sleep } from 'k6';

// Configuration options for the load test.
export const options = {
    duration: '30s',
    vus: 2000,
    thresholds: {
        http_req_duration: ['p(90)<500'],
        http_req_duration: ['p(95)<1000']
    },
}

// Script for load test:
export default function() {
    //const res = http.get('http://10.136.0.115:80/movies-service/api/Movies')

    const data = {
        "movieId":123456789,
        "topicName":"Post load test",
        "content": "This is a load test post description"
    };
    const res = http.post('http://127.0.0.1/feeds-service/api/feed',data);
    sleep(1);
}