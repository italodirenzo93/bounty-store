<template>    
    <div class="container">
        <h1 class="display-3 text-center">Available Bounties</h1>
        <div class="row">
            <div class="col-12 col-sm-6 col-md-3" v-for="bounty in bounties" :key="bounty.id">
                <bounty :bounty="bounty" @claimed="claimBounty" @deleted="deleteBounty"></bounty>
            </div>
        </div>
    </div>
</template>

<script>
import axios from 'axios';
import Bounty from './Bounty';
import {apiEndpoint} from '../config';

export default {
    components: {
        Bounty
    },
    data() {
        return {
            bounties: []
        };
    },
    created() {
        // Get bounties from API
        axios.get(apiEndpoint).then(res => this.bounties = res.data);
    },
    methods: {
        claimBounty(bounty) {
            bounty.captured = true;
        },
        deleteBounty(id) {
            let index = this.bounties.findIndex(b => b.id == id);
            if (index != -1) {
                this.bounties.splice(index, 1);
            } else {
                console.log('index of deleted bounty was -1');
            }
        }
    }
};
</script>

<style>
.bounty {
    margin-bottom: 10px;
}
</style>