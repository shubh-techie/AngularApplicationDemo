import axios, { AxiosInstance, AxiosRequestConfig } from "axios";;

export default class HttpHelperService {
    private asiosInstance: AxiosInstance;
    private config: AxiosRequestConfig;
    constructor() {
        this.asiosInstance = axios.create({
            baseURL:"http://localhost:5000/api/users"
        })
    }

    getUsers() {
        return new Promise<any>((resolve, reject) => {
            this.asiosInstance.get("/all")
                .then(responseObj => {
                    console.log("getUsers" + responseObj)
                    resolve(responseObj);
                }).catch(err => {
                    reject(err);
                });
        });
      }
}