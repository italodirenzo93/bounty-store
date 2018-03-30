<template>    
    <div class="container">
        <h1 class="display-4 text-center">Available Bounties</h1>
        <div class="row">
            <div class="col-12 col-sm-6 col-md-3" v-for="bounty in bounties" :key="bounty.id">
                <bounty :bounty="bounty" @claimed="claimBounty"></bounty>
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
            axios.put(apiEndpoint + '/' + bounty.id, bounty)
                .catch(() => bonuty.captured = false);
        }
    }
};
</script>

<style>
.bounty {
    margin-bottom: 10px;
}
</style>