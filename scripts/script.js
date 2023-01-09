import http from 'k6/http';
import { sleep } from 'k6';

// Configuration options for the load test.
export const options = {
    duration: '30s',
    vus: 2000,
    thresholds: {
        http_req_failed: ['rate<1'],
        http_req_duration: ['p(90)<500'],

    },
}

// Script for load test:
export default function() {
    //const res = http.get('http://10.136.0.115:80/movies-service/api/Movies')
    const res = http.get('http://127.0.0.1/feeds-service/api/feed');
    sleep(1);
}